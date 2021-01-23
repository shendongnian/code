        private const string _mutexId = "MyUniqueId";
        private static Mutex _mutex;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            try
            {
                bool alreadyRunning = false;
                try
                {
                    Mutex.OpenExisting(_mutexId);
                    alreadyRunning = true;
                }
                catch (WaitHandleCannotBeOpenedException)
                {
                    alreadyRunning = false;
                }
                catch
                {
                    alreadyRunning = true;                   
                }
                if (alreadyRunning)
                {
                    using (ServiceController sc = new ServiceController("MyServiceName"))
                    {
                        sc.Stop();
                        sc.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 120));
                        sc.Start();
                    }
                    return;
                }
            }
            catch
            {
            }
            _mutex = new Mutex(true, _mutexId);
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new MyService() 
			};
            // Load the service into memory.
            ServiceBase.Run(ServicesToRun);
            _mutex.Close();
        }
