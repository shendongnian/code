    //this executes very long time, 50s and more, but only once.
    private static SomeObj _someObj = SomeClass.GetSomeObj();
    [WebMethod]
    public string Method1()
    {
        return _someObj.Method1(); //this exetus in a moment 
    }
    [WebMethod]
    public string Method2()
    {
        return _someObj.Method2(); //this exetus in a moment 
    }
