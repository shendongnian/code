    class H
    {
    
    }
    
    class X
    {
        public H HValue { get; private set; }
    
        public X(H h)
        {
            HValue = h;
        }
    }
    
    class H1 : H
    {
        public void Foo() { }
    }
    
    class X1 : X
    {
        public X1(H1 h1) : base(h1)
        {
    
        }
    }
