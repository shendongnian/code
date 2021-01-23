    class Foo : IDisposable
    {
        private bool disposed = false;
        private Thread thread = new Thread(new ThreadStart(DoLotsOfWork));
        private AutoResetEvent endThread = new AutoResetEvent(false);
        private int sum = 0;
        public Foo()
        {
            thread.Start();
        }
        public StopThread()
        {
            endThread.Set();
        }
        public Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void DoLotsOfWork()
        {
            while (!endThread.WaitOne(1000))
            {
                sum += 1;
            }
        }
        private void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                StopThread();
                disposed = true;
            }
        }
    }
    static void Main(string[] args)
    {
        using (Foo foo = new Foo())
        {
            // Additional code...
        }
    }
