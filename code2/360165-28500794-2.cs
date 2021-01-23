    class WinService : ServiceBase
    {
        readonly Program _application = new Program();
      
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] servicesToRun = { new WinService() };
            Run(servicesToRun);
        }
        /// <summary>
        /// Set things in motion so your service can do its work.
        /// </summary>
        protected override void OnStart(string[] args)
        {
            Thread thread = new Thread(() => _application.Start());
            thread.Start();
        }
        /// <summary>
        /// Stop this service.
        /// </summary>
        protected override void OnStop()
        {
            Thread thread = new Thread(() => _application.Stop());
            thread.Start();
        }
    }
