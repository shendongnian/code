    public static IEnumerable<T> MySelectRange<T>(this IEnumerable<T> source,
                                                  Func<T, bool> selector,
                                                  int rangeSize)
    {
        var firstN = new T[rangeSize];
        int pos = 0;
        bool found = false;
        foreach (T item in source)
        {
            if (found)
                if (pos++ <= rangeSize)
                    yield return item;
                else
                    break;
            if (selector(item))
            {
                found = true;
                for (int i = Math.Max(0, pos - rangeSize); i < pos; i++)
                    yield return firstN[i % rangeSize];
                yield return item;
                pos = 0;
            }
            else if (rangeSize > 0)
                firstN[pos++ % rangeSize] = item;
        }
    }
