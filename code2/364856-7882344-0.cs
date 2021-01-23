    public static class DictionaryDefaultExtension
    {
        public static TValue GetOrDefault<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TValue> defaultValue)
        {
            TValue result;
            if (dictionary.TryGetValue(key, out result))
            {
                return result;
            }
            else
            {
                TValue value = defaultValue();
                dictionary[key] = value;
                return value;
            }
        }
    } 
