    public static IEnumerable<TResult> SelectSkipExceptions<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, TResult> selector)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        if (selector == null)
            throw new ArgumentNullException("selector");
        return source.SelectSkipExceptionsIterator(selector);
    }
    private static IEnumerable<TResult> SelectSkipExceptionsIterator<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, TResult> selector)
    {
        foreach(var item in source)
        {
            TResult value = default(TResult);
            try
            {
                value = selector(item);
            }
            catch
            {
                continue;
            }
            yield return value;
        }
    }
