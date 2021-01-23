    void OuterMethod()
    {
        int foo = 1;
        InnerMethod();
        void InnerMethod()
        {
            int bar = 2;
            foo += bar
        }
    }
