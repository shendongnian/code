    class Worker : IDisposable
    {
        private object _outerLocker = new object();
        private object _innerLocker = new object();
        private Func<int> _currentJob;
        private int _currentResult;
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
            Monitor.Enter(_innerLocker);
            while (true)
            {
                Monitor.Wait(_innerLocker); // Wait for client requests
                if (_disposed) break;
                try
                {
                    _currentResult = _currentJob.Invoke();
                    _currentException = null;
                }
                catch (Exception ex)
                {
                    _currentException = ex;
                }
                Monitor.Pulse(_innerLocker); // Notify the waiting client that the job is done
            }
            Monitor.Exit(_innerLocker); // We are done
        }
        public int DoWork(Func<int> job)
        {
            int result;
            Exception exception;
            lock (_outerLocker) // Accept only one client at a time
            {
                lock (_innerLocker) // Acquire inner lock
                {
                    if (_disposed) throw new InvalidOperationException();
                    _currentJob = job;
                    Monitor.Pulse(_innerLocker); // Notify worker thread about the new job
                    Monitor.Wait(_innerLocker); // Wait for worker thread to process the job
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
            lock (_outerLocker)
            {
                lock (_innerLocker)
                {
                    _disposed = true;
                    Monitor.Pulse(_innerLocker); // Notify worker thread to exit loop
                }
            }
        }
    }
