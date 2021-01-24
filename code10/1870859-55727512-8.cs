    using System;
    using System.Diagnostics;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                int[,] matrix = new int[1000, 1000];
                BitMatrix bitMatrix = new BitMatrix(1000, 1000);
                // Randomly populate matrices and calculate expected count.
                var rng = new Random(985912);
                int expected = 0;
                for (int r = 0; r < 1000; ++r)
                {
                    for (int c = 0; c < 1000; ++c)
                    {
                        if ((rng.Next() & 1) == 0)
                            continue;
                        ++expected;
                        matrix[r, c]    = 1;
                        bitMatrix[r, c] = true;
                    }
                }
                Console.WriteLine("Expected = " + expected);
                // Time the explicit matrix loop.
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < 1000; ++i)
                    if (count1(matrix) != expected)
                        Console.WriteLine("count1() failed");
                var elapsed1 = sw.ElapsedTicks;
                Console.WriteLine(sw.Elapsed);
                // Time the hamming weight approach.
                sw.Restart();
                for (int i = 0; i < 1000; ++i)
                    if (bitMatrix.NumSetBits() != expected)
                        Console.WriteLine("NumSetBits() failed");
                var elapsed2 = sw.ElapsedTicks;
                Console.WriteLine(sw.Elapsed);
                Console.WriteLine("BitMatrix matrix is " + elapsed1 / elapsed2 + " times faster");
            }
            static int count1(int[,] matrix)
            {
                int h = 1 + matrix.GetUpperBound(0);
                int w = 1 + matrix.GetUpperBound(1);
                int c = 0;
                for (int i = 0; i < h; ++i)
                    for (int j = 0; j < w; ++j)
                        if (matrix[i, j] == 1)
                            ++c;
                return c;
            }
        }
        public sealed class BitMatrix
        {
            public BitMatrix(int rows, int cols)
            {
                Rows = rows;
                Cols = cols;
                bits = new uint[(rows*cols+31)/32];
            }
            public int Rows { get; }
            public int Cols { get; }
            public int NumSetBits()
            {
                int count = 0;
                foreach (uint i in bits)
                    count += hammingWeight(i);
                return count;
            }
            public bool this[int row, int col]
            {
                get
                {
                    int n = row * Cols + col;
                    int i = n / 32;
                    int j = n % 32;
                    uint m = 1u << j;
                    return (bits[i] & m) != 0;
                }
                set
                {
                    int n = row * Cols + col;
                    int i = n / 32;
                    int j = n % 32;
                    uint m = 1u << j;
                    if (value)
                        bits[i] |= m;
                    else
                        bits[i] &= ~m;
                }
            }
            static int hammingWeight(uint i)
            {
                i = i - ((i >> 1) & 0x55555555);
                i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
                return (int)((((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24);
            }
            readonly uint[] bits;
        }
    }
