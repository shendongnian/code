    class Worker : IDisposable
    {
        private readonly Task _mainTask;
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private volatile Exception _lastException;
        private int _exceptionsCount;
        public Task Completion => _mainTask;
        public Exception LastException => _lastException;
        public int ExceptionsCount => _exceptionsCount;
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
                    await Task.Delay(1000, _cts.Token).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    // Do nothing
                }
                catch (Exception ex)
                {
                    _lastException = ex;
                    Interlocked.Increment(ref _exceptionsCount);
                }
            }
        }
        public void Dispose()
        {
            _cts.Cancel();
        }
    }
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.threading.timer
