    public static IEnumerable<T> FindSandwichedItem<T>(this IEnumerable<T> items, Predicate<T> matchFilling)
    {
        if (items == null)
            throw new ArgumentNullException("items");
        if (matchFilling == null)
            throw new ArgumentNullException("matchFilling");
        return FindSandwichedItemImpl(items, matchFilling);
    }
    private static IEnumerable<T> FindSandwichedItemImpl<T>(IEnumerable<T> items, Predicate<T> matchFilling)
    {
        using(var iter = items.GetEnumerator())
        {
            T previous = default(T);
            while(iter.MoveNext())
            {
                if(matchFilling(iter.Current))
                {
                    yield return previous;
                    yield return iter.Current;
                    if (iter.MoveNext())
                        yield return iter.Current;
                    else
                        yield return default(T);
                    yield break;
                }
                previous = iter.Current;
            }
        }
        // If we get here nothing has been found so return three default values
        yield return default(T); // Previous
        yield return default(T); // Current
        yield return default(T); // Next
    }
