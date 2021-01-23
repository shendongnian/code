    public void Foo()
    {
        DateTime then = System.DateTime.Now;
        // ...
        Console.WriteLine(System.DateTime.Now.Subtract(then).TotalMilliseconds);
    }
