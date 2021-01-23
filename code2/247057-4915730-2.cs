    void Method1()
    {
        x = x ?? new X();
    }
    void Method2()
    {
        if (x == null) x = new X();
    }
