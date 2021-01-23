    class C
    {
        private const int BigSecret = 0x0BADFOOD;
        public static void M() { D.X(BigSecret); }
    }
    class D
    {
        public static void X(int y) { Console.WriteLine(y); }
    }
