    public T GetValueOrDefault<T>(string key)
    {
        if (this.dictionary.TryGetValue(key, out object o))
        {
            return (T)(object)o;
        }
        return default(T);
    }
