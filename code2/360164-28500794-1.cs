        /// <summary>
        /// Used to start as a service
        /// </summary>
        public void Start()
        {
            Main();
        }
        /// <summary>
        /// Used to stop the service
        /// </summary>
        public void Stop()
        {
           if (Application.MessageLoop)
                Application.Exit();   //windows app
            else
                Environment.Exit(1);  //console app
        }
