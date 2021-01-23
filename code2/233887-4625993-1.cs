    public void Foo()
    {
        DateTime then = DateTime.Now;
        // ...
        Console.WriteLine(DateTime.Now.Subtract(then).TotalMilliseconds);
    }
