    var c = a.ExceptBy(b, x => x.Id);
    var r = p.ExceptBy(q, x => x.Name, StringComparer.OrdinalIgnoreCase);
    // ...
    public static class EnumerableExtensions
    {
        public static IEnumerable<TSource> ExceptBy<TSource, TKey>(
            this IEnumerable<TSource> first, IEnumerable<TSource> second,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> keyComparer = null)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");
            if (keySelector == null) throw new ArgumentNullException("keySelector");
            return first.ExceptByIterator(second, keySelector, keyComparer);
        }
        private static IEnumerable<TSource> ExceptByIterator<TSource, TKey>(
            this IEnumerable<TSource> first, IEnumerable<TSource> second,
            Func<TSource, TKey> keySelector, IEqualityComparer<TKey> keyComparer)
        {
            var keys = new HashSet<TKey>(second.Select(keySelector), keyComparer);
            foreach (TSource item in first)
            {
                if (keys.Add(keySelector(item)))
                    yield return item;
            }
        }
    }
