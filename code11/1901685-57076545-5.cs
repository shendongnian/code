    static class EqualityComparerExtensions
    {
        internal static bool Neighbours<T>(this IEqualityComparer<T> comparer, 
            Tuple<T, T> a, Tuple<T, T> b)
        {
            return comparer.Equals(a.Item1, b.Item1) 
                || comparer.Equals(a.Item1, b.Item2)
                || comparer.Equals(a.Item2, b.Item1) 
                || comparer.Equals(a.Item2, b.Item2);
        }
    }
