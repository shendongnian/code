    public class LockObject
    {
        object _syncRoot = new object();
        object _internalSyncRoot = new object();
        public LockToken Lock()
        {
            lock(_internalSyncRoot)
            {
                if(!_hasLock)
                {
                    Monitor.Enter(_syncRoot);
                    _hasLock = true;
                }
                return new LockToken(this);
            }
        }
    
        public void Release()
        {
            lock(_internalSyncRoot)
            {
                if(!_hasLock)
                    return;
                Monitor.Exit(_syncRoot);
                _hasLock = false;
            }
        }
    }
    public class LockToken : IDisposable
    {
        LockObject _lockObject;
        public LockToken(LockObject lockObject) { _lockObject = lockObject; }
        public void Dispose() { _lockObject.Release(); }
    }
