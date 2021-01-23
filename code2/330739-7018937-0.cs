    public void DoSomething() 
    {
        var temp = Tuple.Create("test", "blah blah blah", DateTime.Now);
        DoSomethingElse(temp);
    }
    public void DoSomethingElse(Tuple<string, string, DateTime> data)
    {
        // ...
    }
