    bool onlyPairs = yourArray.ContainsOnlyPairs();
    // ...
    public static class EnumerableExtensions
    {
        public static bool ContainsOnlyPairs<T>(this IEnumerable<T> source)
        {
            var dict = new Dictionary<T, int>();
            foreach (T item in source)
            {
                int count;
                dict.TryGetValue(item, out count);
                if (count > 1)
                    return false;
                dict[item] = count + 1;
            }
            return dict.All(kvp => kvp.Value == 2);
        }
    }
