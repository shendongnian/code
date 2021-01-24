    class Worker : IDisposable
    {
        private readonly Task _mainTask;
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private volatile Exception _lastException;
        private int _exceptionsCount;
        public Task Completion => _mainTask;
        public Exception LastException => _lastException;
        public int ExceptionsCount => Interlocked.Add(ref _exceptionsCount, 0);
        public Worker()
        {
            _mainTask = Task.Run(BackgroundWork);
        }
        private async Task BackgroundWork()
        {
            while (!_cts.IsCancellationRequested)
            {
                try
                {
                    Console.WriteLine("Do work");
                }
                catch (Exception ex)
                {
                    _lastException = ex;
                    Interlocked.Increment(ref _exceptionsCount);
                }
                try
                {
                    await Task.Delay(1000, _cts.Token).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
        }
        public void Dispose()
        {
            _cts.Cancel();
        }
    }
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.threading.timer
