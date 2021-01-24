    void Method(int p, int a, int s)
    {
        if (new [] { p, a, s }.Count(i => i == 0) <= 1)
        {
            throw new Exception("Error please set A or P or S");
        }
    }
