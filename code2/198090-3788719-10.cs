    [Conditional("DEBUG")]
    public void A()
    {
        Console.WriteLine("A");
        B();
    }
    [Conditional("DEBUG")]
    public void B()
    {
        Console.WriteLine("B");
    }
