    public static IEnumerable<T> WithIndexBetween<T>(this IEnumerable<T> source,
        int startInclusive, int endExclusive)
    {
        // The two values can be the same, yielding no results... but they must
        // indicate a reasonable range
        if (endExclusive < startInclusive)
        {
            throw new ArgumentOutOfRangeException("endExclusive");
        }
        return source.Skip(startInclusive).Take(endExclusive - startInclusive);
    }
