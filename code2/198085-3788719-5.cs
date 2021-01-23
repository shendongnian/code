    #if DEBUG
        public void DoSomething() { }
    #endif
    public void Foo()
    {
        DoSomething(); //This will have a compilation error if you're not in DEBUG.
    }
    #if DEBUG
        public void DoSomething() { }
    #endif
        public void Foo()
        {
    #if DEBUG
            DoSomething(); //This works, but looks FUGLY
    #endif
        }
    [Conditional("DEBUG")]
    public void DoSomething() { }
    public void Foo()
    {
        DoSomething(); //Code compiles and is cleaner, DoSomething always
                       //exists, however this is only called during DEBUG.
    }
    
