    public static class DictionaryExtensions
    {
        public static Dictionary<TKey, TValue> AddRange<TKey, TValue>(this Dictionary<TKey, TValue> source,  IEnumerable<ValueTuple<TKey, TValue>> kvps)
        {
            foreach (var kvp in kvps)
                source.Add(kvp.Item1, kvp.Item2);
            return source;
        }
        public static void AddTo<TKey, TValue>(this IEnumerable<ValueTuple<TKey, TValue>> source, Dictionary<TKey, TValue> target)
        {
            target.AddRange(source);
        }
    }
