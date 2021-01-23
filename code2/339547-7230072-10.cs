    public TValue GetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
    {
        try
        {
            return dic[key];
        }
        catch (KeyNotFoundException ex)
        {
            throw new WellknownKeyNotFoundException((object)key, ex.InnerException);
        }
    }
