    public static class Extensions
    {
        public static bool InOrderAscending<T>(this IEnumerable<T> values) 
            where T : struct, IComparable 
        =>
            !values.Zip(values.Skip(1), (value, nextValue) => value.CompareTo(nextValue))
                 .Any(x => x >= 0);
        public static bool InOrderAscending<T>(params T[] values) where T : struct, IComparable 
            => values.InOrderAscending();
    }
