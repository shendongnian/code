    public static IEnumerable<TSource> TakeWhileSingleTerminated<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
    {
        var hasTerminator = false;
        var terminator = default(TSource);
        foreach (var item in source)
        {
            if (!hasFailed)
            {
                if (predicate(item))
                    yield return item;
                else
                {
                    hasTerminator = true;
                    terminator = item;
                }
            }
            else if (!predicate(item))
                throw new InvalidOperationException("Sequence contains more than one terminator");
        }
        if (!hasTerminator)
            throw new InvalidOperationException("Sequence is not terminated");
        yield return terminator;
    }
