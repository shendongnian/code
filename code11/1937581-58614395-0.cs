    public static class IEnumerableExt {
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> src, Func<T, TKey> keySelector, IEqualityComparer<TKey> comparer = null) {
            var seenKeys = new HashSet<TKey>(comparer);
            foreach (var e in src)
                if (seenKeys.Add(keySelector(e)))
                    yield return e;
        }
    }
