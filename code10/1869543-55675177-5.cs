    class KeyedLock
    {
        private object _currentKey;
        private int _currentCount = 0;
        private WaitingQueue _waitingQueue = new WaitingQueue();
        private readonly object _locker = new object();
        public Task WaitAsync(object key, CancellationToken cancellationToken)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            lock (_locker)
            {
                if (_currentKey != null && key != _currentKey)
                {
                    var waiter = new TaskCompletionSource<bool>();
                    _waitingQueue.Enqueue(new KeyValuePair<object,
                        TaskCompletionSource<bool>>(key, waiter));
                    if (cancellationToken != null)
                    {
                        cancellationToken.Register(() => waiter.TrySetCanceled());
                    }
                    return waiter.Task;
                }
                else
                {
                    _currentKey = key;
                    _currentCount++;
                    return cancellationToken.IsCancellationRequested ?
                        Task.FromCanceled(cancellationToken) : Task.FromResult(true);
                }
            }
        }
        public Task WaitAsync(object key) => WaitAsync(key, CancellationToken.None);
        public void Release()
        {
            List<TaskCompletionSource<bool>> tasksToRelease;
            lock (_locker)
            {
                if (_currentCount <= 0) throw new InvalidOperationException();
                _currentCount--;
                if (_currentCount > 0) return;
                _currentKey = null;
                if (_waitingQueue.Count == 0) return;
                var newWaitingQueue = new WaitingQueue();
                tasksToRelease = new List<TaskCompletionSource<bool>>();
                foreach (var entry in _waitingQueue)
                {
                    if (_currentKey == null || entry.Key == _currentKey)
                    {
                        _currentKey = entry.Key;
                        _currentCount++;
                        tasksToRelease.Add(entry.Value);
                    }
                    else
                    {
                        newWaitingQueue.Enqueue(entry);
                    }
                }
                _waitingQueue = newWaitingQueue;
            }
            foreach (var item in tasksToRelease)
            {
                item.TrySetResult(true);
            }
        }
        private class WaitingQueue :
            Queue<KeyValuePair<object, TaskCompletionSource<bool>>>
        { }
        public Task<Releaser> LockAsync(object key,
            CancellationToken cancellationToken)
        {
            var waitTask = this.WaitAsync(key, cancellationToken);
            return waitTask.ContinueWith(
                (_, state) => new Releaser((KeyedLock)state),
                this, cancellationToken,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default
            );
        }
        public Task<Releaser> LockAsync(object key)
            => LockAsync(key, CancellationToken.None);
        public struct Releaser : IDisposable
        {
            private readonly KeyedLock _parent;
            internal Releaser(KeyedLock parent) { _parent = parent; }
            public void Dispose() { _parent?.Release(); }
        }
    }
