    public class SemaphoreFifo
    {
        private readonly Queue<TaskCompletionSource<bool>> _queue
            = new Queue<TaskCompletionSource<bool>>();
        private readonly object _locker = new object();
        private readonly int _maxCount;
        private int _currentCount;
        public SemaphoreFifo(int initialCount, int maxCount)
        {
            _currentCount = initialCount;
            _maxCount = maxCount;
        }
        public SemaphoreFifo(int initialCount) : this(initialCount, Int32.MaxValue) { }
        public int CurrentCount { get { lock (_locker) return _currentCount; } }
        public async Task WaitAsync()
        {
            TaskCompletionSource<bool> tcs;
            lock (_locker)
            {
                if (_currentCount > 0)
                {
                    _currentCount--;
                    return;
                }
                tcs = new TaskCompletionSource<bool>();
                _queue.Enqueue(tcs);
            }
            await tcs.Task;
        }
        public void Starve(int starveCount)
        {
            lock (_locker) _currentCount -= starveCount;
        }
        public void Release()
        {
            TaskCompletionSource<bool> tcs;
            lock (_locker)
            {
                if (_currentCount < 0)
                {
                    _currentCount++;
                    return;
                }
                if (_queue.Count == 0)
                {
                    if (_currentCount >= _maxCount) throw new SemaphoreFullException();
                    _currentCount++;
                    return;
                }
                tcs = _queue.Dequeue();
            }
            tcs.SetResult(true);
        }
    }
