    void Method(int p, int a, int s)
    {
        IEnumerable<int> values() { yield return p; yield return a; yield return s; }
        if (values().Count(i => i == 0) <= 1)
        {
            throw new Exception("Error please set A or P or S");
        }
    }
