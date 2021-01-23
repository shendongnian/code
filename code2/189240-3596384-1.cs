    public static void IterateWithSpecialLast<T>(this IEnumerable<T> source,
        Action<T> allButLastAction,
        Action<T> lastAction)
    {
        using (IEnumerator<T> iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                return;
            }            
            T previous = iterator.Current;
            while (iterator.MoveNext())
            {
                allButLastAction(previous);
                previous = iterator.Current;
            }
            lastAction(previous);
        }
    }
