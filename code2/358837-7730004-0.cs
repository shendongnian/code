    static IEnumerable<T> AllIfNone<T>(this IEnumerable<T> source, 
                                       Func<T, bool> predicate)
    {
        //argument checking ignored for sample purposes
        var buffer = new List<T>();
        bool foundFirst = false;
        foreach (var item in source)
        {
            if (predicate(item))
            {
                foundFirst = true;
                yield return item;
            }
            else if (!foundFirst)
            {
                buffer.Add(item);
            }
        }
        if (!foundFirst)
        {
            foreach (var item in buffer)
            {
                yield return item;
            }
        }
    }
