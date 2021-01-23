    /// <summary> Iterates over all values corresponding to the specified keys, 
    ///for which the key is found in the dictionary. </summary>
    public static IEnumerable<TValue> TryGetValues<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, IEnumerable<TKey> keys)
    {
        TValue value;
        foreach (TKey key in keys)
            if (dictionary.TryGetValue(key, out value))
                yield return value;
    }
    
    /// <summary> Iterates over all values corresponding to the specified keys, 
    ///for which the key is found in the dictionary. A function can be specified to handle not finding a key. </summary>
    public static IEnumerable<TValue> TryGetValues<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, IEnumerable<TKey> keys, Action<TKey> notFoundHandler)
    {
        TValue value;
        foreach (TKey key in keys)
            if (dictionary.TryGetValue(key, out value))
                yield return value;
            else
                notFoundHandler(key);                        
    }
