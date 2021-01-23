    class MultiValueDictionary<TKey, TValue>
    {
        private Dictionary<TKey, List<TValue>> _InternalDict = new Dictionary<TKey, List<TValue>>();
        
        public void Add(TKey key, TValue value)
        {
            if (this._InternalDict.ContainsKey(key))
                this._InternalDict[key].Add(value);
            else
                this._InternalDict.Add(key, new List<TValue>(new TValue[]{value}));
        }
    
        public List<TValue> GetValues(TKey key)
        {
            if (this._InternalDict.ContainsKey(key))
                return this._InternalDict[key];
            else
                return null;
        }
    
    }
