    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*====================================================
             * 
             * Add codes here to set the Winform as Singleton
             * 
             * ==================================================*/
            bool mutexIsAvailable = false;
            Mutex mutex = null;
            try
            {
                mutex = new Mutex(true, "SampleOfSingletonWinForm.Singleton");
                mutexIsAvailable = mutex.WaitOne(1, false); // Wait only 1 ms
            }
            catch (AbandonedMutexException)
            {
                // don't worry about the abandonment; 
                // the mutex only guards app instantiation
                mutexIsAvailable = true;
            }
            if (mutexIsAvailable)
            {
                try
                {
                    Application.Run(new SampleOfSingletonWinForm());
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
            //Application.Run(new SampleOfSingletonWinForm());
        }
    }
