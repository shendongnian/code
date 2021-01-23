    public static void Do<T>(this IEnumerable<T> source, 
                             Action<T> firstItemAction,
                             Action<T> otherItemAction)
    {
       // null-checks omitted
    
        using (var erator = source.GetEnumerator())
        {
            if (!erator.MoveNext())
                return;
           
            firstItemAction(erator.Current);
        
            while (erator.MoveNext())
               otherItemAction(erator.Current);            
        }
    }
