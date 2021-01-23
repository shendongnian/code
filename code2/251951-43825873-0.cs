    public class GlobalStore
    {
        private readonly IDictionary<Type, IEnumerable> _globalStore;
        public GlobalStore()
        {
            _globalStore = new ConcurrentDictionary<Type, IEnumerable>();
        }
        public IEnumerable<T> GetFromCache<T>()
            where T : class 
        {
            return (IEnumerable<T>) _globalStore[typeof(T)];
        }
        public void SetCache<T>(IEnumerable<T> cache)
            where T : class
        {
            _globalStore[typeof(T)] = cache;
        }
    }
