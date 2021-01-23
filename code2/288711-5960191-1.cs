    public static void Main()
    {
        var service = new YourService();
    #if DEBUG
        service.Start();
        Console.ReadLine();
        service.Stop();
    #else
        var ServicesToRun = new System.ServiceProcess.ServiceBase[] { service };
        System.ServiceProcess.ServiceBase.Run(ServicesToRun);
    #endif
    }
