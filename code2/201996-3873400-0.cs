    class A
    {
        protected A(int x)
        {
        }
    }
    class B : A
    {
        B(int x)
            : base(x)
        {
        }
    }
