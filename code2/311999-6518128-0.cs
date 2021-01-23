    class A
    {
        private readonly object syncLock = new object();
        public object SyncLock { get { return syncLock; } }
        public void Update()
        {
            lock(SyncLock)
            {
    
                //(...do stuff...)
    
            }
        }
    }
