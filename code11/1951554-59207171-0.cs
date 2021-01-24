    public class Runner
    {
        private readonly MyClass _object;
        private int _flag;
        public Runner(Object param)
        {
            _object = new MyClass(param);
        }
        public void Start()
        {
            if (Interlocked.CompareExchange(ref _flag, 1, 0) == 0)
            {
                Task.Factory.StartNew(job);
            }
        }
        private void job()
        {
            while (Interlocked.CompareExchange(ref _flag, 1, 1) == 1)
            {
                // do the job on _object
            }
        }
        public void Stop()
        {
            Interlocked.Exchange(ref _flag, 0);
        }
    }
