    public abstract class Monitor
    {
        protected Stopwatch Timer = Stopwatch.StartNew();   
        public abstract void Run();
        public void Test()
        {
            // Warm up to let JIT do it's magic.
            for (int i = 0; i < 1000; i++)
                Run();
            Timer.Start();
            Run();
            Timer.End();
        }
    
    }
