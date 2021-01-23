    public static class Worker
    {
        public static void Execute(params DoWorkEventHandler[] handlers)
        {
            foreach (DoWorkEventHandler handler in handlers)
            {
                BackgroundWorker worker = new BackgroundWorker();
                DoWorkEventHandler capturedHandler = handler;
                worker.DoWork += (sender, e) =>
                {
                    try
                    {
                        capturedHandler(sender, e);
                    }
                    finally
                    {
                        worker.Dispose();    
                    }
                };
                worker.RunWorkerAsync();
            }
        }
    }
