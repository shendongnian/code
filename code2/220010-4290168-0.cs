        public static List<Int64> ToList(byte[] bytes)
        {
            List<Int64> list = new List<Int64>(bytes.Cast<Int64>());
            return list;
        }
        public static byte[] ToBytes(List<Int64> list)
        {
          List<byte> byteList = list.ConvertAll( new Converter<Int64,byte> (Int64Converter)
            return byteList.ToArray();
        }
        public static byte Int64Converter(Int64 x)
        {
            return (byte) x;
        }
