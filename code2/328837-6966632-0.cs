    public class Worker : IDisposable
    {
        private readonly System.Threading.Timer _timer;
        private readonly int PeriodInMs = (int)TimeSpan.FromMinutes(2).TotalMilliseconds;
        public Worker()
        {
            _timer = new System.Threading.Timer(_ => OnTick(), null, Timeout.Infinite, Timeout.Infinite);
        }
        public void Start()
        {
            _timer.Change(0, PeriodInMs);
        }
        public void Stop()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }
        private void OnTick()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            try
            {
                //Your work goes here
            }
            finally
            {
                _timer.Change(PeriodInMs, PeriodInMs);
            }
        }
        public void Dispose()
        {
            _timer.Dispose();
        }
    }
