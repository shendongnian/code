    protected virtual TValue GetValue(TKey key) { ...}
    public TValue this[TKey key]
    {
        get { return GetValue(key); }
        set { ... }
    }
