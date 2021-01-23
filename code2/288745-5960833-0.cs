    public void CallRef()
    {
        string value = "Hello, world";
        DoSomethingWithRef(ref value);
        // Value is now "changed".
    }
    
    public void DoSomethingWithRef(ref string value) 
    {
        value = "changed";
    }
