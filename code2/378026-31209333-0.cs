     public class ScenarioContextSafe
    {
        private static ScenarioContextSafe _current;
        private static readonly object Locker = new object();
        public static ScenarioContextSafe Current
        {
            get
            {
                lock (Locker) {
                    return _current ?? (_current = new ScenarioContextSafe());
                }
            }
        }
        public static void Reset()
        {
            lock (Locker) {                
                _current = null;
            }
        }
        private readonly ConcurrentDictionary<string, object> _concurrentDictionary = new ConcurrentDictionary<string, object>();
        public void Add(string key, object value)
        {
            _concurrentDictionary.TryAdd(key, value);            
        }
        public void Set(object value, string key)
        {
            if (!_concurrentDictionary.ContainsKey(key))
                _concurrentDictionary.TryAdd(key, value);
            else 
                _concurrentDictionary[key] = value;            
        }
        public void Remove(string key)
        {
            object result;
            _concurrentDictionary.TryRemove(key, out result);
        }
        public T Get<T>(string key)
        {
            object result;
            _concurrentDictionary.TryGetValue(key, out result);
            return (T)result;
        }
        public bool ContainsKey(string key)
        {
            return _concurrentDictionary.ContainsKey(key);
        }
        public void Pending()
        {
            ScenarioContext.Current.Pending();            
        }
        public ScenarioInfo ScenarioInfo{
            get { return ScenarioContext.Current.ScenarioInfo; }
        }
    }
