    static class Extensions
    {
        public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T> source)
        {
            return (source ?? Enumerable.Empty<T>());
        }
    }
