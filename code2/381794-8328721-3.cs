    class H1 : H
    {
        H1(X1 x) : base(x)
        {
            MyX1 = x;
        }
        X1 MyX1 { get; private set; }
    }
