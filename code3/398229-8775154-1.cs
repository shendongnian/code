    public  class Count
    {}
    public static class LinqExtensions
    {
        public static int Select<T>(
            this IEnumerable<T> source, Func<T, Count> selector)
        {
            return source.Count();
        }
    }
