    // The method to call
    void Foo()
    {
    }
    
    
    Action action = Foo;
    action.BeginInvoke(ar => action.EndInvoke(ar), null);
