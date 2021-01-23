        public partial class ControllerService : ServiceBase
        {
    
            static void Main(string[] args)
            {
                ControllerService service = new ControllerService();
    
                cmdLine = CommandLineParser.Parse(args);
    
                if (Environment.UserInteractive)
                {
                    switch (cmdLine.StartMode)
                    {
                        case StartMode.Install:
                            //Service Install Code Here
                            break;
                        case StartMode.Uninstall:
                            //Service Uninstall Code Here
                            break;
                        case StartMode.Console:
                        default:
                            service.OnStart(args);
                            consoleCloseEvent.WaitOne();
                            break;
                    }
                }
                else
                {
                    ServiceBase.Run(service);
                }
            }
    
            protected override void OnStart(string[] args)
            {
                 //Do Start Stuff Here
            }
    
            protected override void OnStop()
            {
                if (Environment.UserInteractive)
                {
                    consoleCloseEvent.Set();
                }
            }
       }
