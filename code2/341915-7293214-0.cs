    public static class Worker
    {
        public static void Execute(params DoWorkEventHandler[] handlers)
        {
            foreach (var handler in handlers)
            {
                var worker = new BackgroundWorker();
                worker.DoWork += handler;
                worker.RunWorkerAsync();
            }
        }
    }
