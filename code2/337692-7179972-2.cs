        static void Main()
        {
            // do common initialization, logging framework + the likes
            if (Environment.UserInteractive)
            {
                // start up in user mode
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new myForm());
            }
            else
            {
                // start up as Windows service
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
			    { 
				    new myService() 
			    };
                ServiceBase.Run(ServicesToRun);
            }
        }
