    public static IEnumerable<TResult> Rollup<TSource, TResult>(
        this IEnumerable<TSource> source,
        TResult seed,
        Func<TSource, TResult, TResult> projection)
    {
        TResult nextSeed = seed;
        foreach (TSource src in source)
        {
            TResult projectedValue = projection(src, nextSeed);
            nextSeed = projectedValue;
            yield return projectedValue;
        }
    }
