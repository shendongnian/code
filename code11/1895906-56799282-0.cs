    public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,TKey key) where TValue : new() 
    {
        TValue ret;
        if (!dictionary.TryGetValue(key, out ret))
        {
            ret = new TValue();
            dictionary[key] = ret;
        }
        return ret; 
     }
