    static public void Main(string[] args)
    {
        AppDomain.CurrentDomain.AssemblyResolve += MyEventHandler;
        DeferredMain();
    }
    static public void DeferredMain()
    {
        using(var thing = new Thing())
        {
             // now the event will be triggered, still on JIT and not on execution...
        }
    }
