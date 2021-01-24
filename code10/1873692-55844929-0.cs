public static class DictionaryExtension
{
    public static void AddIfNotNull<TKey, TValue>(
        this IDictionary<TKey, TValue> dict, TKey key, TValue value)
        where TValue : class 
    {
        if (value != null)
        {
            dict[key] = value;
        }
    }
}
textItem.attributes.AddIfNotNull(1, null); //won't be added
textItem.attributes.AddIfNotNull(1, "a"); //will be added
