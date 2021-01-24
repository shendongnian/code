    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ForEach(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (T item in enumerable)
            {
                action(item);
            }
        }
    }
