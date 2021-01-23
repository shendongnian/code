    public void DoSomething(IEnumerable<object> things)
    {
        foreach(var foo in things.OfType<IFoo>())
        {
            foo.Bar();
        }
    }
