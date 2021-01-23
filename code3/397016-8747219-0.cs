    class Example
    {
        private static readonly object SyncRoot = new object();
        void ReadOrWrite()
        {
            lock(SyncRoot)
            {
                // Perform a read or write
            }
        }
    }
