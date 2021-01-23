    private void Startup()
    {
        new Thread(WorkerProc) { IsBackground = true }
        .Start();
    }
    private void WorkerProc()
    {
        int pollPeriod = 50;
        while (true)
        {
            var et = Environment.TickCount;
            
            // call your methods
            et = Environment.TickCount - et;
            var sleep = pollPeriod - et;
            if (sleep < 0) sleep = 0; // always yield
            Thread.Sleep(sleep);
        }
    }
 
