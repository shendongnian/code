    if (source is IList<TSource> list)
    {
        for (int i = list.Count - 1; i >= 0; --i)
        {
            TSource result = list[i];
            if (predicate(result))
            {
                found = true;
                return result;
            }
        }
    }
