    public class Cache<T> where T : class
    {
        private readonly MemoryCache cache = new MemoryCache();
        public T this[string key]
        {
            get { return (T) cache[key]; }
            set { cache[key] = value; }
        }
        // etc
    }
