    class Worker<TResult> : IDisposable
    {
        private readonly object _outerLock = new object();
        private readonly object _innerLock = new object();
        private Func<TResult> _currentJob;
        private TResult _currentResult;
        private Exception _currentException;
        private bool _disposed;
        public Worker()
        {
            var thread = new Thread(MainLoop);
            thread.IsBackground = true;
            thread.Start();
        }
        private void MainLoop()
        {
            lock (_innerLock)
            {
                while (true)
                {
                    Monitor.Wait(_innerLock); // Wait for client requests
                    if (_disposed) break;
                    try
                    {
                        _currentResult = _currentJob.Invoke();
                        _currentException = null;
                    }
                    catch (Exception ex)
                    {
                        _currentException = ex;
                        _currentResult = default;
                    }
                    Monitor.Pulse(_innerLock); // Notify the waiting client that the job is done
                }
            } // We are done
        }
        public TResult DoWork(Func<TResult> job)
        {
            TResult result;
            Exception exception;
            lock (_outerLock) // Accept only one client at a time
            {
                lock (_innerLock) // Acquire inner lock
                {
                    if (_disposed) throw new InvalidOperationException();
                    _currentJob = job;
                    Monitor.Pulse(_innerLock); // Notify worker thread about the new job
                    Monitor.Wait(_innerLock); // Wait for worker thread to process the job
                    result = _currentResult;
                    exception = _currentException;
                    // Clean up
                    _currentJob = null;
                    _currentResult = default;
                    _currentException = null;
                }
            }
            // Throw the exception, if occurred, preserving the stack trace
            if (exception != null) ExceptionDispatchInfo.Capture(exception).Throw();
            return result;
        }
        public void Dispose()
        {
            lock (_outerLock)
            {
                lock (_innerLock)
                {
                    _disposed = true;
                    Monitor.Pulse(_innerLock); // Notify worker thread to exit loop
                }
            }
        }
    }
