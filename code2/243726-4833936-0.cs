    ServiceHost MyServiceHost = new ServiceHost(myService, myBaseAddress);
    
    #if CONFIG = "Debug"
    //set Service Debug Behavior (for security should not be enabled during deployment)
    Description.ServiceDebugBehavior sdb = MyServiceHost.Description.Behaviors.Find<Description.ServiceDebugBehavior>();
    if (sdb == null) {
	sdb = new Description.ServiceDebugBehavior();
	MyServiceHost.Description.Behaviors.Add(sdb);
    }
    sdb.IncludeExceptionDetailInFaults = true;
    #endif
    MyServiceHost.AddServiceEndpoint(typeof(IMyService), new NetTcpBinding(), myBaseAddress);
    MyServiceHost.Open();
