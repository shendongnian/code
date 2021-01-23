    public static class MakeArrayExtension
    {
        public static U[] MakeArray<T, U>(this IEnumerable<T> collection, Func<T,U> func)
        {
            return collection.Select(func).ToArray();
        }
    }
