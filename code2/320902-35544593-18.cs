    /// <summary>
    /// Compares two dictionaries for equality using a custom value equality function.
    /// </summary>
    /// <returns>
    /// True if both dictionaries are null or both have the same set of keys and comparing
    /// their respective values for each key using the <paramref name="valueEqualityFunc"/>
    /// returns true, otherwise false.
    /// </returns>
    public static bool DictionaryEqual<TKey, TValue1, TValue2>(
        this IDictionary<TKey, TValue1> dict1, IDictionary<TKey, TValue2> dict2,
        Func<TValue1, TValue2, bool> valueEqualityFunc)
    {
        if (valueEqualityFunc == null)
            throw new ArgumentNullException("valueEqualityFunc");
        if (dict1 == dict2)
            return true;
        if (dict1 == null | dict2 == null)
            return false;
        if (dict1.Count != dict2.Count)
            return false;
        return dict1.All(kvp =>
        {
            TValue2 value2;
            return dict2.TryGetValue(kvp.Key, out value2)
                && valueEqualityFunc(kvp.Value, value2);
        });
    }
