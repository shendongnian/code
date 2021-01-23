    public void DoSomething(IEnumerable<IFoo> things)
    {
       foreach(var o in things)
       {
               o.Bar();
       }
    }
