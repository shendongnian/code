    public class MaxThreadCountWorker : IDisposable
    {
        private readonly int _maxThreadCount;
        private readonly int _tickIntervalMilliseconds;
        private readonly Action _periodicWork;
        private readonly System.Threading.Timer _timer;
        private int _currentActiveCount;
        public MaxThreadCountWorker(int maxThreadCount, int tickIntervalMilliseconds, Action periodicWork)
        {
            _maxThreadCount = maxThreadCount;
            _tickIntervalMilliseconds = tickIntervalMilliseconds;
            _periodicWork = periodicWork;
            _timer = new System.Threading.Timer(_ => OnTick(), null, Timeout.Infinite, Timeout.Infinite);
            _currentActiveCount = 0;
        }
        public void Start()
        {
            _timer.Change(0, _tickIntervalMilliseconds);
        }
        public void Stop()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }
        private void DoWork()
        {
            try
            {
                _periodicWork.Invoke();
            }
            finally
            {
                Interlocked.Decrement(ref _currentActiveCount);
            }
        }
        private void OnTick()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            try
            {
                if (_currentActiveCount >= _maxThreadCount) return;
                Interlocked.Increment(ref _currentActiveCount);
                ThreadPool.QueueUserWorkItem(_ => DoWork());
            }
            finally
            {
                _timer.Change(_tickIntervalMilliseconds, _tickIntervalMilliseconds);
            }
        }
        public void Dispose()
        {
            _timer.Dispose();
        }
    } 
    class Program
    {
        private static object _lockObject = new object();
        private static int _runningTasks = 0;
        private static void PrintToConsole()
        {
            lock (_lockObject)
            {
                _runningTasks += 1;
            }
            try
            {
                Console.WriteLine("Starting work. Total active: {0}", _runningTasks);
                var r = new Random();
                System.Threading.Thread.Sleep(r.Next(3500));                
            } finally
            {
                lock (_lockObject)
                {
                    _runningTasks -= 1;
                }                
            }
        }
        static void Main(string[] args)
        {
            using (var w = new MaxThreadCountWorker(3, 150, PrintToConsole))
            {
                w.Start();
                Console.ReadKey();
            }
        }
    }
