    public Foo DoSomething(int x, int y)
    {
        var mb = MethodBase.GetCurrentMethod();
        var parameters = new Hashtable();
        parameters.Add("x", x);
        parameters.Add("y", y);
        return (Foo)
            CallDatabaseMemberFunction("GET", parameters, typeof(Foo));
    }
