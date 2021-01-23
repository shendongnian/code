    public static class ListKeyValuePairExtensions
    {
        public static void Add<S, T>(this List<KeyValuePair<S, T>> list, S key, T value)
        {
            list.Add(new KeyValuePair<S, T>(key, value));
        }
    }
