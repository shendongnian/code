    [Conditional("DEBUG")]
    public void DoSomething() { }
    public void Foo()
    {
        DoSomething(); //Code compiles and is cleaner, DoSomething always
                       //exists, however this is only called during DEBUG.
    }
    
