    //this executes very long time, 50s and more, but only once.
    private static SomeObj _someObj1 = SomeClass.GetSomeObj();
    private static SomeObj _someObj2 = SomeClass.GetSomeObj();
    [WebMethod]
    public string Method1()
    {
        return _someObj1.Method1(); //this exetus in a moment 
    }
    [WebMethod]
    public string Method2()
    {
        return _someObj2.Method2(); //this exetus in a moment 
    }
