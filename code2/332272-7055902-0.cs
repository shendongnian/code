    public class NoLockTimer : IDisposable
    {
        private readonly Timer _timer;
        public NoLockTimer()
        {
            _timer = new Timer { AutoReset = false, Interval = 1000 };
            _timer.Elapsed += delegate
            {
                //Do some stuff
                _timer.Start(); // <- Manual restart.
            };
            _timer.Start();
        }
        public void Dispose()
        {
            if (_timer != null)
            {
                _timer.Dispose();
            }
        }
    } 
