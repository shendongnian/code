    [Conditional("DEBUG")]
    public void Foo()
    {
        // Stuff
    }
    // This call will only be compiled into the code if the DEBUG symbol is defined
    Foo();
