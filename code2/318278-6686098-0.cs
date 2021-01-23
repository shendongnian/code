    class Supervisor
    {
        EventWaitHandle waitHandle = new AutoResetEvent(false);
        public bool Success { get; set; }
        // launch worker thread and wait for result
        public void Start()
        {
            while (true)
            {
                Thread thread = new Thread(() => { new Worker(new DoneDelegate(WorkerDone)).DoWork(); });
                thread.IsBackground = true;
                thread.Start();
                waitHandle.WaitOne(); // wait for worker to finish
                if (!Success) break; // handle error here
            }
        }
        // callback for worker to report result
        public void WorkerDone(bool successArg)
        {
            Success = successArg;
            // wake up supervisor
            waitHandle.Set();
        }
    }
    public delegate void DoneDelegate(bool successArg);
    class Worker
    {
        public DoneDelegate Done { get; set; }
        public Worker(DoneDelegate doneArg)
        {
            Done = doneArg;
        }
        public void DoWork()
        {
            // simulate work and exception
            Random rnd = new Random();
            Thread.Sleep(1000);
            try
            {
                int i = 10 / (1 - new Random().Next(5));
                Done(true);
            }
            catch
            {
                Done(false);
            }
        }
    }
