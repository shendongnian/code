    void Method1()
    {
        if (x == null) x = new X();
    }
    void Method2()
    {
        x = x ?? new X();
    }
