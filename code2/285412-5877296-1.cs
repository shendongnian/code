    class State : IDisposable
    {
        private List<object> _objects;
        private ReaderWriterLockSlim _locker;
        private object _cacheLocker;
        private List<object> _objectsCache;
        private Thread _synchronizeThread;
        private AutoResetEvent _synchronizationEvent;
        private bool _abortThreadToken;
        public State()
        {
            _objects = new List<object>();
            _objectsCache = new List<object>();
            
            _cacheLocker = new object();
            _locker = new ReaderWriterLockSlim();
            _synchronizationEvent = new AutoResetEvent(false);
            _abortThreadToken = false;
            _synchronizeThread = new Thread(Synchronize);
            _synchronizeThread.Start();
        }
        
        private void Synchronize()
        {
            while (!_abortThreadToken)
            {
                _synchronizationEvent.WaitOne();
                
                int objectsCacheCount;
                lock (_cacheLocker)
                {
                    objectsCacheCount = _objectsCache.Count;
                }
                if (objectsCacheCount > 0)
                {
                    _locker.EnterWriteLock();
                    
                    lock (_cacheLocker)
                    {
                        _objects.AddRange(_objectsCache);
                        _objectsCache.Clear();
                    }
                    _locker.ExitWriteLock();
                }
            }
        }
        public IEnumerator<object> GetEnumerator()
        {
            _locker.EnterReadLock();
            foreach (var o in _objects)
            {
                yield return o;
            }
            _locker.ExitReadLock();
        }
        
        // Called by message handler thread
        public void HandleMessage()
        {
            lock (_cacheLocker)
            {
                _objectsCache.Add(new object());
            }
            _synchronizationEvent.Set();
        }
        public void Dispose()
        {
            _abortThreadToken = true;
        }
    }
