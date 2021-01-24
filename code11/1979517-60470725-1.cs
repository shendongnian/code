    public class AsyncSemaphorePlus
    {
        private readonly object _locker = new object();
        private readonly Queue<(TaskCompletionSource<bool>, int)> _queue
            = new Queue<(TaskCompletionSource<bool>, int)>();
        private int _currentCount;
        public int CurrentCount { get { lock (_locker) return _currentCount; } }
        public AsyncSemaphorePlus(int initialCount)
        {
            if (initialCount < 0)
                throw new ArgumentOutOfRangeException(nameof(initialCount));
            _currentCount = initialCount;
        }
        public Task WaitAsync(int count)
        {
            lock (_locker)
            {
                if (_currentCount - count >= 0)
                {
                    _currentCount -= count;
                    return Task.CompletedTask;
                }
                else
                {
                    var tcs = new TaskCompletionSource<bool>(
                        TaskCreationOptions.RunContinuationsAsynchronously);
                    _queue.Enqueue((tcs, count));
                    return tcs.Task;
                }
            }
        }
        public void Release(int count)
        {
            lock (_locker)
            {
                _currentCount += count;
                while (_queue.Count > 0)
                {
                    var (tcs, weight) = _queue.Peek();
                    if (weight > _currentCount) break;
                    (tcs, weight) = _queue.Dequeue();
                    _currentCount -= weight;
                    tcs.SetResult(true);
                }
            }
        }
    }
