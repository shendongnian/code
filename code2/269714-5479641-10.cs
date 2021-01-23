    public static IEnumerable<TSource> TakeWhileSingleTerminated<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
    {
        bool hasFailed = false;
        var terminator = default(TSource);
        foreach (var item in source)
        {
            if (!hasFailed)
            {
                if (predicate(item))
                    yield return item;
                else
                {
                    hasFailed = true;
                    terminator = item;
                }
            }
            else if (!predicate(item))
                throw new InvalidOperationException("Sequence contains more than one terminator");
        }
        if (!hasFailed)
            throw new InvalidOperationException("Sequence is not terminated");
        yield return terminator;
    }
