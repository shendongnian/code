    public static IEnumerable<T> FindSandwichedItem(this IEnumerable<T> items, Predicate<T> matchFilling)
    {
        // Check args
        return FindSandwichedItemImpl(items, matchFilling);
    }
    private static IEnumerable<T> FindSandwichedItemImpl(IEnumerable<T> items, Predicate<T> matchFilling)
    {
        using(var iter = items.GetEnumerator())
        {
            T previous = default(T);
            while(iter.MoveNext())
            {
                if(matchFilling(iter.Current))
                {
                    yield return previous;
                    yield return iter.Current();
                    if (iter.MoveNext())
                        yield return iter.Current();
                    else
                        yield return default(T);
                    break;
                }
                previous = iter.Current;
            }
        }
    }
