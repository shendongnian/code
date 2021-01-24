    //Startup.cs
    services.AddSingleton<ISomeLibrary>(new SomeLibrary());
    
    ....
    
    //controller
    public SomeController : Controller
    {
    	private readonly ISomeLibrary _sl;
    
    	public SomeController(ISomeLibrary sl)
    	{
    		_sl = sl;
    	}
    
    	...
    }
