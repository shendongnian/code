    static void Main(string[]] args) 
    { 
        if (args.Length == 0)
        {
              //Service entry
              System.ServiceProcess.ServiceBase[] services; 
              services = new System.ServiceProcess.ServiceBase[] { new WinService1() }; 
              System.ServiceProcess.ServiceBase.Run(services);
        }
        else
        {
              //Console entry
              OnStart(args);
        } 
    }
    protected override void OnStart(string[] args)
    {
        base.OnStart(args);
        Console.WriteLine("Sham-Wow!");
    }
   
