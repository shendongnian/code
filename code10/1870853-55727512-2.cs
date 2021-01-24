    public sealed class BitMatrix
    {
        public BitMatrix(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            bits = new ulong[(rows*cols+63)/64];
        }
        public int Rows { get; }
        public int Cols { get; }
        public int NumSetBits()
        {
            int count = 0;
            foreach (ulong i in bits)
                count += hammingWeight(i);
            return count;
        }
        public bool this[int row, int col]
        {
            get
            {
                int n = row * Cols + col;
                int i = n / 64;
                int j = n % 64;
                ulong m = 1ul << j;
                return (bits[i] & m) != 0;
            }
            set
            {
                int n = row * Cols + col;
                int i = n / 64;
                int j = n % 64;
                ulong m = 1ul << j;
                if (value)
                    bits[i] |= m;
                else
                    bits[i] &= ~m;
            }
        }
        static int hammingWeight(ulong i)
        {
            i = i - ((i >> 1) & 0x5555555555555555UL);
            i = (i & 0x3333333333333333UL) + ((i >> 2) & 0x3333333333333333UL);
            return (int)(unchecked(((i + (i >> 4)) & 0xF0F0F0F0F0F0F0FUL) * 0x101010101010101UL) >> 56);
        }
        readonly ulong[] bits;
    }
