        private static bool stopProcessing;
        private static object __batchProcessLock;
        private static const int sleeptime = 2500;//2.5 seconds
        protected void Application_Start(object sender, EventArgs e)
        {
            Thread BatchThread = new Thread(Start);
        }
        protected void Application_End(object sender, EventArgs e)
        {
            Stop();
        }
        private static void Start()
        {
            lock (__batchProcessLock) // Be sure to run this only once in the application
            { 
                stopProcessing = false;
                while (!stopProcessing)
                {
                    try
                    {
                        //Do you stuff (check if it is time to send emails)
                    }
                    catch (Exception ex)
                    {
                        //handle exception
                    }
                    Sleep(sleeptime); 
                }
            }
        }
        private static void Stop()
        {
            stopProcessing = true;
        }
