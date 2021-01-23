    public static IEnumerable<T[]> InPairsOfTwo<T>(this IEnumerable<T> enumerable)
    {
        if (enumerable.Count() < 2) throw new ArgumentException("...");
        
        T lastItem = default(T);
        bool isNotFirstIteration = false;
        foreach (T item in enumerable)
        {
            if (isNotFirstIteration)
            {
                yield return new T[] { lastItem, item };
            }
            else
            {
                isNotFirstIteration = true;
            }
            lastItem = item;
        }
    }
