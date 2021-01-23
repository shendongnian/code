    public void Foo()
    {
        int x = 10;
        Bar(ref x);
        Console.WriteLine(x); // Prints 20
    }
    public void Bar(ref int y)
    {
        y = 20;
    }
