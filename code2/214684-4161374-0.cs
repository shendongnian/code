    public void Foo<T>(T x)
    {
        if (x == null)
            throw new ArgumentNullException("x");
    
        Delegate d = x as Delegate;
        if (d == null)
            throw new ArgumentException("Argument must be of Delegate type.", "x");
    
        // Use d here.
    }
