    class X
    {
    }
    class X1 : X
    {
    }
    class H
    {
        H(X x)
        {
            MyX = x;
        }
        X MyX { get; private set; }
    }
    class H1 : H
    {
        H1(X x) : base(x)
        {
        }
    }
