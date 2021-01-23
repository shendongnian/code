    public void Caller3()
    {
        var s = "input";
        Console.WriteLine("Before: {0}", s);
        ChangeString(ref s);
        Console.WriteLine("After: {0}", s);
    }
    public void ChangeString(ref string s)
    {
        s = "output";
    }
