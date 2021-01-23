    public static TSource MaxBy<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, IComparable> projectionToComparable
    ) {
        using (var e = source.GetEnumerator()) {
            if (!e.MoveNext()) {
                throw new InvalidOperationException("Sequence is empty.");
            }
            TSource max = e.Current;
            IComparable maxProjection = projectionToComparable(e.Current);
            while (e.MoveNext()) {
                IComparable currentProjection = projectionToComparable(e.Current);
                if (currentProjection.CompareTo(maxProjection) > 0) {
                    max = e.Current;
                    maxProjection = currentProjection;
                }
            }
            return max;                
        }
    }
