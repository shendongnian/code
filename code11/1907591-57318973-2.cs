    class Trend
    {
        private readonly Action _action;
        private CancellationTokenSource _cts;
        private Task _task = Task.CompletedTask;
        public Task Completion { get => _task; }
        public Trend(Action action) { _action = action; } // Constructor
        public void CompleteAfter(int msec)
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();
            _task = Task.Delay(msec, _cts.Token).ContinueWith(t =>
            {
                if (!t.IsCanceled) _action?.Invoke();
            }, TaskContinuationOptions.ExecuteSynchronously);
        }
    }
