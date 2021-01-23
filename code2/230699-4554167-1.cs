    // add a reference to System.ServiceProcess.dll
    using System.ServiceProcess;
    
    // ...
    ServiceController ctl = ServiceController.GetServices().Where(s=>s.ServiceName == "myservice").FirstOrDefault();
    if(ctl==null)
        Console.WriteLine("Not installed");
    else    
        Console.WriteLine(ctl.Status);
