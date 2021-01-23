    public void Visit<TItem>(this IEnumerable<TItem> theList, Action<TItem, TItem> visitor)
    {
        using (var e = theList.GetEnumerator())
        {
            TItem first = default(TItem), second = default(TItem);
            while (e.MoveNext())
            {
                first = e.Current;
                if (e.MoveNext())
                {
                    second = e.Current;
                }
                visitor(first, second);
                first = default(TItem);
                second = default(TItem);
            }
        }
    }
