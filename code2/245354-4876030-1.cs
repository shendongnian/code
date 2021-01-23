    class Example2
    {
        public static int K { get; set; }
        
        static Example2()
        {
            K = 0;
        }
        // These two methods have *exactly* the same CIL
        public int StaticMethodLong()
        {
            return Example2.K;
        }
        public int StaticMethodShort()
        {
            return K;
        }
