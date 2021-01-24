    public static class Extensions
    {
        public static TOut Map<TIn, TOut>(this TIn value, Func<TIn, TOut> map)
            where TIn : class
            => value == null ? default(TOut) : map(value);
        public static IEnumerable<T> OrEmpty<T>(this IEnumerable<T> items)
            => items ?? Enumerable.Empty<T>();
    }
