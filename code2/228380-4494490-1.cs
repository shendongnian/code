    static public void Main(string[] args)
    {
        AppDomain.CurrentDomain.AssemblyResolve += MyEventHandler;
        MyMain();
    }
    // The CLR will actually try to load your assembly before even starting the execution
    // of this method. It needs the assembly in order to JIT the method because it has to know
    // the Thing type.
    static public void MyMain()
    {
        using(var thing = new Thing())
        {
             // ...
        }
    }
