    internal class AsyncResult<T> : IAsyncResult
    {
        private ManualResetEvent _manualResetEvent = new ManualResetEvent(false);
    
        public object AsyncState => null;
    
        public WaitHandle AsyncWaitHandle => _manualResetEvent;
    
        public bool CompletedSynchronously => false;
    
        public bool IsCompleted { get; private set; }
    
        public T Result { get; private set; }
    
        public Exception Error { get; private set; }
    
        public AsyncResult(IFuture<T> future)
        {
            future.OnSuccess(result =>
                {
                    Result = result;
                    IsCompleted = true;
                    _manualResetEvent.Set();
                });
    
            future.OnError(() =>
            {
                Error = future.error;
                IsCompleted = true;
                _manualResetEvent.Set();
            });
        }
    }
    
