    public static class EnumerableExtensions
    {
        public static bool HasItem(this IEnumerable enumerable, object value)
        {
            return enumerable.OfType<Object>().Any(e => e.Equals(value));
        }
    }
