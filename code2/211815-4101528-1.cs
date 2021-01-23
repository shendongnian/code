    public static IEnumerable<IEnumerable<TSource>> GroupConsecutive<TSource,TKey>(
            this IEnumerable<TSource> source, Func<TSource,TKey> keySelector) {
        if (source == null) throw new ArgumentNullException("source");
        if (keySelector == null) throw new ArgumentNullException("keySelector");
        
        var comparer = EqualityComparer<TKey>.Default;
        var grouped = new List<TSource>();
        using (var iter = source.GetEnumerator()) {
            if (!iter.MoveNext()) yield break;
            grouped.Add(iter.Current);
            var last = iter.Current;
            while (iter.MoveNext()) {
                if (!comparer.Equals(keySelector(iter.Current), keySelector(last))) {
                    yield return grouped.AsReadOnly();
                    grouped = new List<TSource>();
                }
                grouped.Add(iter.Current);
                last = iter.Current;
            }
            yield return grouped.AsReadOnly();
        }
    }
