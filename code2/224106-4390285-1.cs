    public static void Do(this IEnumerable<T> source, 
                        Action<T> firstItemAction,
                        Action<T> otherItemAction)
    {
       // null-checks omitted
    
        using (var erator = source.GetEnumerator())
        {
            if (erator.MoveNext())
            {
                firstItemAction(erator.Current);
        
                while (erator.MoveNext())
                    otherItemAction(erator.Current);
            }
        }
    }
