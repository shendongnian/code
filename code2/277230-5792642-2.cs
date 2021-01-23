    _runner = RealtimeRunner.CreateInNewThreadAndAppDomain(
    	operationalRange,
    	_rootElement.Identifier,
    	Settings.Environment,
    	new FailureNotifier());
    	
    ...
    
    /// <summary>
    /// Create a new realtime processor, it loads in a background thread/appdomain
    /// After calling this the RealtimeRunner will automatically do an initial run and then enter and event loop waiting for events
    /// </summary>
    /// <param name="flowdayRange"></param>
    /// <param name="rootElement"></param>
    /// <param name="environment"></param>
    /// <returns></returns>
    public static RealtimeRunner CreateInNewThreadAndAppDomain(
    	DateTimeRange flowdayRange,
    	byte rootElement,
    	ApplicationServerMode environment,
    	IFailureNotifier failureNotifier)
    {
    	string runnerName = string.Format("RealtimeRunner_{0}_{1}_{2}", flowdayRange.StartDateTime.ToShortDateString(), rootElement, environment);
    
    	// Create the AppDomain and MarshalByRefObject
    	var appDomainSetup = new AppDomainSetup()
    	{
    		ApplicationName = runnerName,
    		ShadowCopyFiles = "false",
    		ApplicationBase = Environment.CurrentDirectory,
    	};
    	var calcAppDomain = AppDomain.CreateDomain(
    		runnerName,
    		null,
    		appDomainSetup,
    		new PermissionSet(PermissionState.Unrestricted));
    
    	var runnerProxy = (RealtimeRunner)calcAppDomain.CreateInstanceAndUnwrap(
    		typeof(RealtimeRunner).Assembly.FullName,
    		typeof(RealtimeRunner).FullName,
    		false,
    		BindingFlags.NonPublic | BindingFlags.Instance,
    		null,
    		new object[] { flowdayRange, rootElement, environment, failureNotifier },
    		null,
    		null);
    
    	Thread runnerThread = new Thread(runnerProxy.BootStrapLoader)
    	{
    		Name = runnerName,
    		IsBackground = false
    	};
    	runnerThread.Start();
    
    	return runnerProxy;
    }
