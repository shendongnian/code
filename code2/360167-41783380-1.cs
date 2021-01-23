    using System.ServiceProcess;
    
    namespace MyService
    {
        class Service : ServiceBase
        {
            public Service()
            {
                ServiceName = Program.ServiceName;
            }
    
            protected override void OnStart(string[] args)
            {
                Program.Start(args);
            }
    
            protected override void OnStop()
            {
                Program.Stop();
            }
        }
    }
