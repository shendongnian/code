    // add a reference to System.ServiceProcess.dll
    using System.ServiceProcess;
    
    // ...
    ServiceController ctl = ServiceController.GetServices()
        .FirstOrDefault(s => s.ServiceName == "myservice");
    if(ctl==null)
        Console.WriteLine("Not installed");
    else    
        Console.WriteLine(ctl.Status);
