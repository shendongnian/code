    public delegate object CommonDelegate();
    class X
    {
        CommonDelegate d;
        public X(CommonDelegate d)
        {
            this.d = d; // store the delegate for later
        }
    }
