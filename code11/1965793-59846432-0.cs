public static ImmutableDictionary<TKey, TValue> AddAndThrowIfAlreadyPresent<TKey, TValue>(
    ImmutableDictionary<TKey, TValue> dict,
    TKey key,
    TValue value)
{
    // null checks, etc
    var newDict = dict.Add(key, value);
    if (newDict == dict)
        throw new ArgumentException($"An element with the same key and value already exists. Key: {key}");
    return newDict;
}
