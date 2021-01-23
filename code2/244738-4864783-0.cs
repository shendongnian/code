    // The main entry point for the process 
    static void Main() 
    { 
        System.ServiceProcess.ServiceBase[] ServicesToRun; 
        ServicesToRun = new System.ServiceProcess.ServiceBase[] { new WinService1() }; 
        System.ServiceProcess.ServiceBase.Run(ServicesToRun); 
    } 
