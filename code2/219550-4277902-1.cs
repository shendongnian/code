    class TheService : ServiceBase
    {
       static void Main(string[] args)
            {
                if (!Environment.UserInteractive)
                {
                    Run(new TheService());
                }
                else
                {
                    // If interactive, start up as a console app for easy debugging and/or installing/uninstalling the service
                    switch (string.Concat(args))
                    {
                        case "/i":
                            ManagedInstallerClass.InstallHelper(new[] { Assembly.GetExecutingAssembly().Location });
                            break;
                        case "/u":
                            ManagedInstallerClass.InstallHelper(new[] { "/u", Assembly.GetExecutingAssembly().Location });
                            break;
                        default:
                            Console.WriteLine("Running service in console debug mode (use /i or /u to install or uninstall the service)");
                            var service = new TheService();
                            service.OnStart(null);
                            Thread.Sleep(Timeout.Infinite);
                            break;
                    }
                }
            }
       }
