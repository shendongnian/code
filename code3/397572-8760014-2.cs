    public static IEnumerable<T> FindSandwichedItem(this IEnumerable<T> items, Predicate<T> matchFilling)
    {
        if (items == null)
            throw new ArgumentNullException("items");
        if (matchFilling == null)
            throw new ArgumentNullException("matchFilling");
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
