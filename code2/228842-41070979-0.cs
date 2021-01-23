    namespace DictionaryEx
    {
        public static class Ex
        {
            public static TV Vivify<TK, TV>(this IDictionary<TK, TV> dict, TK key)
            {
                var value = default(TV);
                if (dict.TryGetValue(key, out value))
                {
                    return value;
                }
                value = default(TV);
                dict[key] = value;
                return value;
            }
    
            public static TV Vivify<TK, TV>(this IDictionary<TK, TV> dict, TK key, TV defaultValue)
            {
                TV value;
                if (dict.TryGetValue(key, out value))
                {
                    return value;
                }
                dict[key] = defaultValue;
                return defaultValue;
            }
    
            public static TV Vivify<TK, TV>(this IDictionary<TK, TV> dict, TK key, Func<TV> valueFactory)
            {
                TV value;
                if (dict.TryGetValue(key, out value))
                {
                    return value;
                }
                value = valueFactory();
                dict[key] = value;
                return value;
            }
        }
    }
