    static class Example
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source,
            Func<T, int, bool> predicate)
        {
            int index = 0;
            foreach (var item in source)
            {
                if (predicate(item, index++)) yield return item;
            }
        }
    }
