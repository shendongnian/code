    public static class Extensions
    {
        public static bool HasElements(
            this IEnumerable<T> l1, 
            IEnumerable<T> l2,
            IEqualityComparer<T> comparaer)
        {
            l2.Count() == l1.Count() && 
            return l1.Intersect(l2, comparer).Count() == l2.Count();
        } 
    }
