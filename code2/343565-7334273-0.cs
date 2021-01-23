     public static class DictionaryExtension
        {
            public static void AddItemIfNotExist<TKey,TValue>(this Dictionary<TKey,TValue> dictionary, TKey key,TValue item)
            {
                if (!dictionary.ContainsKey(key))
                {
                    dictionary.Add(key, item);
                }
            }
        }
