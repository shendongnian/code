    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            // Startup as service.
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                    new Service1()
            };
            if (Environment.UserInteractive)
            {
                RunInteractive(ServicesToRun);
            }
            else
            {
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
