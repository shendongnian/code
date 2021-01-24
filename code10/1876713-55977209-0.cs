    //in Startup.cs
    services.AddOptions<MyOptionsClass>()
    .Configure(o =>
    {
        o.Data = "test";
    });
    //then in the controller
    public MyController(IOptionsMonitor<MyOptionsClass> optionsAccessor)
    {        
        //note: Configure is called as MyController gets created by DI
        var data = optionsAccessor.CurrentValue.Data;
    }
