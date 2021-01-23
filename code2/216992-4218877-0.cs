    public static class ByteArrayHelpers
    {
        private static readonly int[] LookupTable =
            Enumerable.Range(0, 256).Select(CountBits).ToArray();
        private static int CountBits(int value)
        {
            int count = 0;
            for (int i=0; i < 8; i++)
            {
               count += (value >> i) & 1;
            }
            return sum;
        }
        public static int CountBitsAfterXor(byte[] array)
        {
            int xor = 0;
            foreach (byte b in array)
            {
                xor ^= b;
            }
            return LookupTable[xor];
        }
    }
