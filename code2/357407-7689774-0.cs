    class A
    {
        public A(int x, int y)
        {
            // do something
        }
    }
    class A2 : A
    {
        public A2() : base(1, 5)
        {
            // do something
        }
        public A2(int x, int y) : base(x, y)
        {
            // do something
        }
        // This would not compile:
        public A2(int x, int y)
        {
            // the compiler will look for a constructor A(), which doesn't exist
        }
    }
