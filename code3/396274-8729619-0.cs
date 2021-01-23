    public class NamedSyncRoot
    {
        private object _syncRoot;
    
        public string Name { get; private set; }
    
        public NamedSyncRoot(string name)
        {
            Name = name;
            _syncRoot = new object();
        }
    
        public void Lock()
        {
            Monitor.Enter(_syncRoot);
        }
    
        public void Unlock()
        {
            Monitor.Exit(_syncRoot);
        }
    }
    
    public class Foo
    {
        private static NamedSyncRoot namedLock = new NamedSyncRoot("Foo");
    
        public void Bar()
        {
            namedLock.Lock();
            //...
            namedLock.Unlock();
        }
    }
