    public void Caller2()
    {
        var s = "input";
        Console.WriteLine("Before: {0}", s);
        TryToChangeString(s);
        Console.WriteLine("After: {0}", s);
    }
    public void TryToChangeString(string s)
    {
        s = "output";
    }
