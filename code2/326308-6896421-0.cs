    public static IDictionary<TKey, TValue> AddIfNullCreate<TKey, TValue>
        (this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
    {
        if (dictionary == null)
        {
            dictionary = new Dictionary<TKey, TValue>();
        }
        dictionary.Add(key, value);
        return dictionary;
    }
