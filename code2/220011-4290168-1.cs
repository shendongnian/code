        public static List<Int64> ToList(byte[] bytes)
        {
            var list = new List<Int64>();
            for (int i = 0; i < bytes.Length; i += sizeof(Int64))
                list.Add(BitConverter.ToInt64(bytes, i));
            return list;
        }
        public static byte[] ToBytes(List<Int64> list)
        {
          var byteList = list.ConvertAll(new Converter<Int64, byte[]>(Int64Converter));
          List<byte> resultList = new List<byte>();
          byteList.ForEach(x => { resultList.AddRange(x); });
          return resultList.ToArray();
        }
        public static byte[] Int64Converter(Int64 x)
        {
            return BitConverter.GetBytes(x);
        }
