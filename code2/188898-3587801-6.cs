    public static class DictionaryExtensions
    { 
        public static TValue FindOrAdd<TKey,TValue>( 
                 this IDictionary<TKey,TValue> dictionary, TKey key, TValue value )
            where TValue : new()
        { 
            TValue value; 
            if (!this.TryGetValue(key, out value)) 
            { 
                value = new TValue(); 
                this.Add(key, value); 
            } 
            return value; 
        } 
    }
 
