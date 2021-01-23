    public class LockProvider
    {
        private readonly object globalLock = new object();
        private readonly Dictionary<String, Locker> locks =
            new Dictionary<string, Locker>(StringComparer.Ordinal);
        public IDisposable Enter(string key)
        {
            Locker locker;
            lock (this.globalLock)
            {
                if (!this.locks.TryGetValue(key, out locker))
                {
                    this.locks[key] = locker = new Locker(this, key);
                }
                // Increase wait count ínside the global lock
                locker.WaitCount++;
            }
            // Call Enter and decrease wait count óutside the 
            // global lock (to prevent deadlocks).
            locker.Enter();
            // Only one thread will be here at a time for a given locker.
            locker.WaitCount--;
            return locker;
        }
        private sealed class Locker : IDisposable
        {
            private readonly LockProvider provider;
            private readonly string key;
            private object keyLock = new object();
            public int WaitCount;
            public Locker(LockProvider provider, string key)
            {
                this.provider = provider;
                this.key = key;
            }
            public void Enter()
            {
                Monitor.Enter(this.keyLock);
            }
            public void Dispose()
            {
                if (this.keyLock != null)
                {
                    this.Exit();
                    this.keyLock = null;
                }
            }
            private void Exit()
            {
                lock (this.provider.globalLock)
                {
                    try
                    {
                        // Remove the key before releasing the lock, but
                        // only when no threads are waiting (because they
                        // will have a reference to this locker).
                        if (this.WaitCount == 0)
                        {
                            this.provider.locks.Remove(this.key);
                        }
                    }
                    finally
                    {
                        // Release the keyLock inside the globalLock.
                        Monitor.Exit(this.keyLock);
                    }
                }
            }
        }
    }
