        static int[] long2doubleInt(long a) {
            int a1 = (int)(a & uint.MaxValue);
            int a2 = (int)(a >> 32);
            return new int[] { a1, a2 };
        }
        static long doubleInt2long(int a1, int a2)
        {
            long b = a2;
            b = b << 32;
            b = b | (uint)a1;
            return b;
        }
        static void Main(string[] args)
        {
            long a = 12345678910111213;
            int[] al = long2doubleInt(a);
            long ap = doubleInt2long(al[0],al[1]);
            System.Console.WriteLine(ap);
            System.Console.ReadKey();
        }
