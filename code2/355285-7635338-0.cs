    class TwoKeyDictionary<T> : Dictionary<string, Dictionary<string, T>>
    {
        public new IEnumerable<T> this[string key1]
        {
            get { return base[key1].Values; }
        }
    
        public T this[string key1, string key2]
        {
            get { return base[key1][key2]; }
        }
    
        public void Add(string key1, string key2, T item)
        {
            if (!base.ContainsKey(key1))
                base[key1] = new Dictionary<string, T>();
            base[key1].Add(key2, item);
        }
    }
