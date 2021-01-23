    using System;
    using System.Configuration.Install;
    using System.Reflection;
    using System.ServiceProcess;
    using System.IO;
    
    namespace ConsoleApplication1
    {
        class Program : ServiceBase
        {
            static void Main(string[] args)
            {
    
                AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;
    
    
                if (System.Environment.UserInteractive)
                {
                    string parameter = string.Concat(args);
                    switch (parameter)
                    {
                        case "--install":
                            ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
                            break;
                        case "--uninstall":
                            ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
                            break;
                    }
                }
                else
                {
                    ServiceBase.Run(new Program());
                }
    
    
    
            }
    
            private static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
            {
                File.AppendAllText(@"C:\Temp\error.txt", ((Exception)e.ExceptionObject).Message + ((Exception)e.ExceptionObject).InnerException.Message);
            }
    
            public Program()
            {
                this.ServiceName = "My Service";
                File.AppendAllText(@"C:\Temp\sss.txt", "aaa");
    
            }
    
            protected override void OnStart(string[] args)
            {
                base.OnStart(args);
    
                File.AppendAllText(@"C:\Temp\sss.txt", "bbb");
            }
    
            protected override void OnStop()
            {
                base.OnStop();
    
                File.AppendAllText(@"C:\Temp\sss.txt", "ccc");
            }
        }
    }
