    public class TaskAggregator
    {
        private int _activeCount = 0;
        private int _isAddingCompleted = 0;
        private TaskCompletionSource<bool> _tcs = new TaskCompletionSource<bool>();
        public Task Task { get => _tcs.Task; }
        public int ActiveCount
        {
            get => Interlocked.CompareExchange(ref _activeCount, 0, 0);
        }
        public bool IsAddingCompleted
        {
            get => Interlocked.CompareExchange(ref _isAddingCompleted, 0, 0) != 0;
        }
        public void Add(Task task)
        {
            Interlocked.Increment(ref _activeCount);
            task.ContinueWith(_ =>
            {
                int localActiveCount = Interlocked.Decrement(ref _activeCount);
                if (localActiveCount == 0 && this.IsAddingCompleted)
                    _tcs.TrySetResult(true);
            }, TaskContinuationOptions.ExecuteSynchronously);
        }
        public void CompleteAdding()
        {
            Interlocked.Exchange(ref _isAddingCompleted, 1);
            if (this.ActiveCount == 0) _tcs.TrySetResult(true);
        }
    }
