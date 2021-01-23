        private static IPFIX ParseMessageHeader(byte[] bytes)
        {
            IPFIX ret = new IPFIX();
            ret.Version = ToUInt16BigEndian(bytes, 0);
            ret.Length = ToUInt16BigEndian(bytes, 2);
            ret.ExportTime = (new DateTime(1970, 1, 1, 0, 0, 0)).AddSeconds(ToUInt32BigEndian(bytes, 4));
            ret.SequenceNumber = ToUInt32BigEndian(bytes, 8);
            ret.ObservationDomainID = ToUInt32BigEndian(bytes, 12);
            return ret;
        }
        //These two functions are from here http://snipplr.com/view/15179/adapt-systembitconverter-to-handle-big-endian-network-byte-ordering-in-order-to-create-number-types-from-bytes-and-viceversa/
        //BitConverter.ToUInt16 would parse the results in "little endian" order so 0x000a would actually be parsed as 0x0a00 and give you 2,560 instead of 10.
        //The spec says that everything should be in "big endian" (also known as "network order"
        public static UInt16 ToUInt16BigEndian(byte[] value, int startIndex)
        {
            return System.BitConverter.ToUInt16(value.Reverse().ToArray(), value.Length - sizeof(UInt16) - startIndex);
        }
        public static UInt32 ToUInt32BigEndian(byte[] value, int startIndex)
        {
            return System.BitConverter.ToUInt32(value.Reverse().ToArray(), value.Length - sizeof(UInt32) - startIndex);
        }
        struct IPFIX
        {
            public UInt16 Version;
            public UInt16 Length;
            public DateTime ExportTime;
            public UInt32 SequenceNumber;
            public UInt32 ObservationDomainID;
        }
