    public class ThreadPerformance : IDisposable
    {
        private Stopwatch _totalStopwatch = new Stopwatch();
        private ExecutionStopwatch _executionStopwatch = new ExecutionStopwatch();
    
        public static ThreadPerformance Measure()
        {
            return new ThreadPerformance();
        }
    
        private ThreadPerformance()
        {
            _totalStopwatch.Start();
            _executionStopwatch.Start();
        }
    
        public void Dispose()
        {
            _executionStopwatch.Stop();
            _totalStopwatch.Stop();
            Console.WriteLine("Performance mesurement for thread {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Waiting: {0}", _totalStopwatch.Elapsed - _executionStopwatch.Elapsed);
            Console.WriteLine("CPU usage: {0}", _executionStopwatch.Elapsed);
        }
    }
