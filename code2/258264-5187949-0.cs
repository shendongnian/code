    // Simple illustration only, not claiming this is awesome code!
    class Cache<T>
    {
        private T _instance;
    
        public T Get()
        {
            if (_instance == null)
            {
                _instance = Create();
            }
    
            return _instance;
        }
    
        protected virtual T Create()
        {
            return Activator.CreateInstance<T>();
        }
    }
