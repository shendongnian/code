    using System;
    using System.IO;
    using System.ServiceProcess;
    
    namespace MyService
    {
        class Program
        {
            public const string ServiceName = "MyService";
    
            static void Main(string[] args)
            {
                if (Environment.UserInteractive)
                {
                    // running as console app
                    Start(args);
    
                    Console.WriteLine("Press any key to stop...");
                    Console.ReadKey(true);
    
                    Stop();
                }
                else
                {
                    // running as service
                    using (var service = new Service())
                    {
                        ServiceBase.Run(service);
                    }
                }
            }
    
            public static void Start(string[] args)
            {
                File.AppendAllText(@"c:\temp\MyService.txt", String.Format("{0} started{1}", DateTime.Now, Environment.NewLine));
            }
    
            public static void Stop()
            {
                File.AppendAllText(@"c:\temp\MyService.txt", String.Format("{0} stopped{1}", DateTime.Now, Environment.NewLine));
            }
        }
    }
