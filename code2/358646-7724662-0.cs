        protected void Application_Start(object sender, EventArgs e)
        {
            Thread BatchThread = new Thread(BatchProcessFacade.Start);
        }
        protected void Application_End(object sender, EventArgs e)
        {
            Stop();
        }
        private static void Start()
        {
            lock (__batchProcessLock) // Be sure to run this only once in the application
            { 
                stoppedProcessing = false;
                stopProcessing = false;
                while (!stopProcessing)
                {
                    try
                    {
                        //Do you stuff
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Processing error in batch process", ex);
                    }
                    Sleep(sleeptime);
                }
            }
            stoppedProcessing = true;
        }
        private static void Stop()
        {
            stopProcessing = true;
        }
