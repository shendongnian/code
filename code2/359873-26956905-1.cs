    // an object of some type
    MyCustomObject obj = new MyCustomObject();
    
    // set up obj and Process
    
    process.OutputDataReceived +=
        (Object _sender, DataReceivedArgs _args) =>
            DoSomething(obj, _sender, _args);
    
    public void DoSomething(Process process, Object sender, DataReceivedArgs args)
    {
        // do some stuff
    }
