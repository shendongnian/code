    public static TSource Last<TSource>(this IEnumerable<TSource> source)
    {
        ...
        if (list != null)
        {
            int count = list.Count;
            if (count > 0)
            {
                return list[count - 1];
            }
        }
        else
        {
            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
                ...
            }
        }
        throw Error.NoElements();
    }
