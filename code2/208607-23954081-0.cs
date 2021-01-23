    public static class Extensions
    {
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> list)
        {
                return list.ToDictionary(x => x.Key, x => x.Value);
        } 
    }
