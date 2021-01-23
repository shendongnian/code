    class Program
    {
        private static int A = 10;
        private static int B = 100;
        private static byte[] _linear;
        private static byte[,] _square;
        private static byte[][] _jagged;
        unsafe static void Main(string[] args)
        {
            //init arrays
            _linear = new byte[A * B];
            _square = new byte[A, B];
            _jagged = new byte[A][];
            for (int i = 0; i < A; i++)
                _jagged[i] = new byte[B];
            //set-up the params
            var sw = new Stopwatch();
            byte b;
            const int N = 100000;
            //one-dim array (buffer)
            sw.Restart();
            for (int i = 0; i < N; i++)
            {
                for (int r = 0; r < A; r++)
                {
                    for (int c = 0; c < B; c++)
                    {
                        b = _linear[r * B + c];
                    }
                }
            }
            sw.Stop();
            Console.WriteLine("linear={0}", sw.ElapsedMilliseconds);
            //two-dim array
            sw.Restart();
            for (int i = 0; i < N; i++)
            {
                for (int r = 0; r < A; r++)
                {
                    for (int c = 0; c < B; c++)
                    {
                        b = _square[r, c];
                    }
                }
            }
            sw.Stop();
            Console.WriteLine("square={0}", sw.ElapsedMilliseconds);
            //jagged array
            sw.Restart();
            for (int i = 0; i < N; i++)
            {
                for (int r = 0; r < A; r++)
                {
                    for (int c = 0; c < B; c++)
                    {
                        b = _jagged[r][c];
                    }
                }
            }
            sw.Stop();
            Console.WriteLine("jagged={0}", sw.ElapsedMilliseconds);
            //one-dim array within unsafe access (and context)
            sw.Restart();
            for (int i = 0; i < N; i++)
            {
                for (int r = 0; r < A; r++)
                {
                    fixed (byte* offset = &_linear[r * B])
                    {
                        for (int c = 0; c < B; c++)
                        {
                            b = *(byte*)(offset + c);
                        }
                    }
                }
            }
            sw.Stop();
            Console.WriteLine("unsafe={0}", sw.ElapsedMilliseconds);
            Console.Write("Press any key...");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
