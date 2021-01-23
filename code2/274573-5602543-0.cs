    public abstract class Monitor
    {
        private readonly Stopwatch Timer = new Stopwatch(); 
        public void Run()
        {
            Timer.Start();
            DoRun();
            Timer.Stop();
        }
    
        protected abstract void DoRun();
    }
