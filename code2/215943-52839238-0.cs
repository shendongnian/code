    // Returns an Object to Lock with based on a string Value
    private static readonly ConditionalWeakTable<string, object> _weakTable = new ConditionalWeakTable<string, object>();
    public static object GetLock(string value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        return _weakTable.GetOrCreateValue(value.ToLower());
    }
