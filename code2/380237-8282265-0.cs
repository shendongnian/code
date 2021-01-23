    class DisposableLock
    {
        public bool IsAcquired { get; set; }
        class Handle : IDisposable
        {
            private DisposableLock parent;
            public void Dispose()
            {
                parent.IsAcquired = false;
                Monitor.Exit(parent);
            }
        }
        public IDisposable Acquire()
        {
            var handle = new Handle();
            handle.parent = this;
            handle.parent.IsAcquired = true;
            Monitor.Enter(this);
            return handle;
        }
    }
