    public struct MyStruct
    {
        public MyStruct(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public int A { get { return a; } }
        public int B { get { return b; } }
        private readonly int a, b;
        internal int C { get { return a + b; } }
    }
