    class State
    {
        List<object> m_objects = new List<object>();
        ReaderWriterLockSlim locker = new ReaderWriterLockSlim();
        public IEnumerator<object> GetEnumerator()
        {
            locker.EnterReadLock();
            
            foreach (var o in Objects)
            {
                yield return o;
            }
            locker.ExitReadLock();
        }
        private List<object> Objects
        {
            get { return m_objects; }
            set { m_objects = value; }
        }
        // Called by message handler thread
        public void HandleMessage()
        {
            locker.EnterWriteLock();
            
            Objects.Add(new object());
            
            locker.ExitWriteLock();
        }
    }
