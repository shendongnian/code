    public static IEnumerable<TResult> SelectAndAct<TSource, TResult>
        (this IEnumerable<TSource> source,
         Func<TSource, TResult> projection,
         Action<TSource, TResult> action)
    {
        foreach (TSource item in source)
        {
            TResult result = projection(item);
            action(item, result);
            yield return result;
        }
    }
