    class A
    {
        public A(Foo bar)
        {
        }
    }
    
    class A2 : A
    {
        public A2()
            : base(new Foo())
        {
        }
    }
