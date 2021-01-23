    static void Main(string[] args)
    {
        // 'If' block will execute when launched through Visual Studio
        if (Environment.UserInteractive)
        {
            ServiceMonitor serviceRequest = new ServiceMonitor();
            serviceRequest.TestOnStartAndOnStop(args);
        }
        else // This block will execute when code is compiled as a Windows application
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new ServiceMonitor()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
