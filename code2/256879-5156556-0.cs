    static void Main(string[] args)
    {
        if ((1 == args.Length) && ("-runAsApp" == args[0]))
        {
            Application.Run(new application_form());
        }
        else
        {
            System.ServiceProcess.ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] { new MyService() };
            System.ServiceProcess.ServiceBase.Run(ServicesToRun);
        }
    }
