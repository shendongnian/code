    public Foo DoSomething(int x, int y)
    {
        var mb = MethodBase.GetCurrentMethod();
        var parameters = new Hashtable();
        var storedProcMethodName = (ArrayList)ParameterMap[mb.Name];
        parameters.Add("x", x);
        parameters.Add("y", y);
        return (Foo)
            CallDatabaseMemberFunction("GET", parameters, typeof(Foo));
    }
