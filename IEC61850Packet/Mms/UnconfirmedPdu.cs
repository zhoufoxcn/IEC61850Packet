﻿using IEC61850Packet.Asn1;
using PacketDotNet.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiscUtil.Conversion;
using IEC61850Packet.Utils;

namespace IEC61850Packet.Mms
{
    public class UnconfirmedPdu : MmsPdu
    {
        public UnconfirmedService Service { get; set; }
        public UnconfirmedDetail Service_Ext { get; set; }

        public UnconfirmedPdu()
        {
            // According to the MMS standard's defination.
            this.Identifier = BerIdentifier.Encode(BerIdentifier.ContextSpecific, BerIdentifier.Constructed, 3);
        }

        public UnconfirmedPdu(ByteArraySegment bas, TLV parent)
            : this()
        {
            TLV pdu = new TLV(bas, parent);

           // UnconfirmedServiceType serviceType = (UnconfirmedServiceType)(EndianBitConverter.Big.ToInt8(, 0));
            Service = new UnconfirmedService(pdu.Tag.RawBytes,pdu.Value.Bytes);
            // Fill the Bytes.
            base.Bytes = bas;

        }

    }
}
