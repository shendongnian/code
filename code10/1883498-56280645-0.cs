    public static class ExtensionMethods
    {
        public static IEnumerable<T> TakeHighests<T>(this IEnumerable<T> collection, int count)
        {
            return collection.OrderByDescending(i => i) // Sort the enumerable (arrays are also enumerables). Use OrderBy() for N lowest items
                .Take(count) // Take only `count` items
        }
    }
