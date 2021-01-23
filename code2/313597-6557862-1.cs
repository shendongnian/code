    public static class IDictionaryExtensions
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
  			T i;
    		dictionary.TryGetValue(key, out i);
            return i;
        }
    }
    
