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
        public WaitResult Wait(TKey key,
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
                ReleaseLockItem(lockItem, key);
                throw;
            }
            return new WaitResult(this, lockItem, key, acquired);
        }
        public async Task<WaitResult> WaitAsync(TKey key,
            int millisecondsTimeout = Timeout.Infinite,
            CancellationToken cancellationToken = default)
        {
            var lockItem = GetLockItem(key);
            bool acquired;
            try
            {
                acquired = await lockItem.Semaphore.WaitAsync(millisecondsTimeout,
                    cancellationToken).ConfigureAwait(false);
            }
            catch
            {
                ReleaseLockItem(lockItem, key);
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
        private void ReleaseLockItem(LockItem lockItem, TKey key)
        {
            lock (Locker)
            {
                lockItem.UsedCount -= 1;
                if (lockItem.UsedCount == 0)
                {
                    if (Dictionary.TryGetValue(key, out var stored))
                    {
                        if (stored == lockItem) // Sanity check
                        {
                            Dictionary.Remove(key);
                            if (Pool.Count < PoolSize)
                            {
                                Pool.Enqueue(lockItem);
                            }
                        }
                    }
                }
            }
        }
        internal class LockItem
        {
            public SemaphoreSlim Semaphore { get; } = new SemaphoreSlim(1);
            public int UsedCount { get; set; }
        }
        public struct WaitResult : IDisposable
        {
            private MultiLock<TKey> MultiLock { get; }
            private LockItem LockItem { get; }
            private TKey Key { get; }
            public bool LockAcquired { get; }
            internal WaitResult(MultiLock<TKey> multiLock, LockItem lockItem, TKey key,
                bool acquired)
            {
                MultiLock = multiLock;
                LockItem = lockItem;
                Key = key;
                LockAcquired = acquired;
            }
            void IDisposable.Dispose()
            {
                MultiLock.ReleaseLockItem(LockItem, Key);
                LockItem.Semaphore.Release();
            }
        }
    }
