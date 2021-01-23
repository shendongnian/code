    public static class EnumerableEx
    {
        public static IEnumerable<T> GetDuplicates<T>(this IEnumerable<T> source)
        {
            return source.GroupBy(t => t).Where(x => x.Count() > 1).Select(x => x.Key);
        }
    }
