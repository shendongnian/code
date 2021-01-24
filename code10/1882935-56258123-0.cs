    static void Main()
    {
    /////IF DEBUG The service will create all resource and allow code stepthrough
    #if (!DEBUG)
        //NO DEBUG - Production code ran here
        System.ServiceProcess.ServiceBase[] ServicesToRun;
        ServicesToRun = new System.ServiceProcess.ServiceBase[] { new MyService() };
        System.ServiceProcess.ServiceBase.Run(ServicesToRun);
    #else
        // Debug code: this allows the process to run as a non-service.
        // It will kick off the service start point, but never kill it.
        // Shut down the debugger to exit
        MyService service = new MyService();
        service.OnStart(null);    
        System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
    #endif 
    }
