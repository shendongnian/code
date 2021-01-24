    public static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> sequence)
        {
            return !(sequence?.Any() ?? false);
        }
    }
