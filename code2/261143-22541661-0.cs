    public void Example(int required, string StrVal = "default", int IntVal = 0)
    {
        // ...
    }
    public void Test()
    {
        // This gives compiler error
        // Example(1, 10);
        // This works
        Example(1, IntVal:10);
    }
