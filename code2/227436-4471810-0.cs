    public sealed partial class Algorithm<T>
    {
        private static object ExecuteForSomeType(DataCache dataCache)
        {
            return new SomeType();
        }
    }
    
    public sealed partial class Algorithm<T>
    {
        private static object ExecuteForSomeOtherType(DataCache dataCache)
        {
            return new SomeOtherType();
        }
    }
    
    public sealed partial class Algorithm<T>
    {
        private readonly Dictionary<System.Type, Func<DataCache, object>> _algorithms = new Dictionary<System.Type, Func<DataCache, object>>();
        private readonly Dictionary<DataCache, WeakReference> _resultsWeak = new Dictionary<DataCache, WeakReference>();
        private readonly Dictionary<DataCache, T> _resultsStrong = new Dictionary<DataCache, T>();
    
        private Algorithm() { }
        private static Algorithm<T> _instance;
        public static Algorithm<T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Algorithm<T>();
                    _instance._algorithms.Add(typeof(SomeType), ExecuteForSomeType);
                    _instance._algorithms.Add(typeof(SomeOtherType), ExecuteForSomeOtherType);
                }
                return _instance;
            }
        }
    
        public T ComputeResult(DataCache dataCache, bool save = false)
        {
            T returnValue = (T)(new object());
            if (_resultsStrong.ContainsKey(dataCache))
            {
                returnValue = _resultsStrong[dataCache];
                return returnValue;
            }
            if (_resultsWeak.ContainsKey(dataCache))
            {
                returnValue = (T)_resultsWeak[dataCache].Target;
                if (returnValue != null) return returnValue;
            }
    
            returnValue = (T)_algorithms[returnValue.GetType()](dataCache);
            _resultsWeak[dataCache] = new WeakReference(returnValue, true);
            if (save) _resultsStrong[dataCache] = returnValue;
    
            return returnValue;
        }
    }
