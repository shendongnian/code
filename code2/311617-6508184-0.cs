    public Visit<TItem>(this IEnumerable<TItem> theList,
                             Action<TItem, TItem> visitor)
    {
        TItem prev = default(TItem);
        using (var iterator = theList.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                return;
            }
            prev = iterator.Current;
            while (iterator.MoveNext())
            {
                TItem current = iterator.Current;
                visitor(prev, current);
                prev = current;
            }
        }
        visitor(prev, default(TItem)); // Are you sure you want this?
    }
