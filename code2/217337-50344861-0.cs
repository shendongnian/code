     public static ulong GetFixedCode(uint x, uint y)
        {
            var array1 = BitConverter.GetBytes(x);
            var array2 = BitConverter.GetBytes(y);
            List<byte> resultArray = new List<byte>();
            resultArray.AddRange(array1.ToList().GetRange(0, 2));
            resultArray.AddRange(array2.ToList().GetRange(0, 2));
            resultArray.AddRange(array1.ToList().GetRange(2, 2));
            resultArray.AddRange(array2.ToList().GetRange(2, 2));
            return BitConverter.ToUInt64(resultArray.ToArray(), 0);
        }
