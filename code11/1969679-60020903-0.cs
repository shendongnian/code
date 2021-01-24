    public class MultiLock<TKey>
    {
        private object Locker { get; } = new object();
        private Dictionary<TKey, LockItem> Dictionary { get; }
        private Queue<LockItem> Pool { get; }
        private int PoolSize { get; }
        public MultiLock(int poolSize = 10)
        {
            Dictionary = new Dictionary<TKey, LockItem>();
            Pool = new Queue<LockItem>(poolSize);
            PoolSize = poolSize;
        }
        public IWaitResult Wait(TKey key,
            int millisecondsTimeout = Timeout.Infinite,
            CancellationToken cancellationToken = default)
        {
            var lockItem = GetLockItem(key);
            bool acquired;
            try
            {
                acquired = lockItem.Semaphore.Wait(millisecondsTimeout,
                    cancellationToken);
            }
            catch
            {
                new WaitResult(this, lockItem, key, false).Dispose();
                throw;
            }
            return new WaitResult(this, lockItem, key, acquired);
        }
        public async Task<IWaitResult> WaitAsync(TKey key,
            int millisecondsTimeout = Timeout.Infinite,
            CancellationToken cancellationToken = default)
        {
            var lockItem = GetLockItem(key);
            bool acquired;
            try
            {
                acquired = await lockItem.Semaphore.WaitAsync(millisecondsTimeout,
                    cancellationToken);
            }
            catch
            {
                new WaitResult(this, lockItem, key, false).Dispose();
                throw;
            }
            return new WaitResult(this, lockItem, key, acquired);
        }
        private LockItem GetLockItem(TKey key)
        {
            LockItem lockItem;
            lock (Locker)
            {
                if (!Dictionary.TryGetValue(key, out lockItem))
                {
                    if (Pool.Count > 0)
                    {
                        lockItem = Pool.Dequeue();
                    }
                    else
                    {
                        lockItem = new LockItem();
                    }
                    Dictionary.Add(key, lockItem);
                }
                lockItem.UsedCount += 1;
            }
            return lockItem;
        }
        private class LockItem
        {
            public SemaphoreSlim Semaphore { get; } = new SemaphoreSlim(1);
            public int UsedCount { get; set; }
        }
        public interface IWaitResult : IDisposable
        {
            bool LockAcquired { get; }
        }
        private struct WaitResult : IWaitResult
        {
            private MultiLock<TKey> MultiLock { get; }
            private LockItem LockItem { get; }
            private TKey Key { get; }
            public bool LockAcquired { get; }
            public WaitResult(MultiLock<TKey> multiLock, LockItem lockItem, TKey key,
                bool acquired)
            {
                MultiLock = multiLock;
                LockItem = lockItem;
                Key = key;
                LockAcquired = acquired;
            }
            public void Dispose()
            {
                lock (MultiLock.Locker)
                {
                    LockItem.UsedCount -= 1;
                    if (LockItem.UsedCount == 0)
                    {
                        if (MultiLock.Dictionary.TryGetValue(Key, out var stored))
                        {
                            if (stored == LockItem) // Sanity check
                            {
                                var removed = MultiLock.Dictionary.Remove(Key);
                                if (MultiLock.Pool.Count < MultiLock.PoolSize)
                                {
                                    MultiLock.Pool.Enqueue(LockItem);
                                }
                            }
                        }
                    }
                }
                LockItem.Semaphore.Release();
            }
        }
    }
