      public static Int16 ToInt16(byte[] data, int offset)
        {
            return BitConverter.ToInt16(BitConverter.IsLittleEndian ? data.Reverse().ToArray() : data, offset);
        }
        public static Int32 ToInt32(byte[] data, int offset)
        {
            return BitConverter.ToInt32(BitConverter.IsLittleEndian ? data.Reverse().ToArray() : data, offset);
        }
        public static Int64 ToInt64(byte[] data, int offset)
        {
            return BitConverter.ToInt64(BitConverter.IsLittleEndian ? data.Reverse().ToArray() : data, offset);
        }
