    public class Example()
    {
        public IEnumerable<X> GetReadOnlySnapshot()
        {
            lock (padLock)
            {
                return new ReadOnlyCollection<X>( MasterList );
            }
        }
        private object padLock = new object();
    }
