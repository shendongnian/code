    public void CallDelegate(DelegateWithParameters method)
    {
        method(1, 2);
    }
    public void Test(int a,int b)
    {
        // Do something
    }
    
    // Use it like so
    CallDelegate(Test);
