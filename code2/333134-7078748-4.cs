    class SomeObject
    {
        private readonly object syncRoot = new object();
        public object SyncRoot { get { return syncRoot; } }
        ...
    }
