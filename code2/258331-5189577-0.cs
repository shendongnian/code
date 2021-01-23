    public static int IndexOfMaxBy<TSource, TProjected>
        (this IEnumerable<TSource> source,
         Func<TSource, TProjected> selector,
         IComparer<TProjected> comparer = null
        )
    {
    
        //null-checks here
    
        using (var erator = source.GetEnumerator())
        {
            if (!erator.MoveNext())
                throw new InvalidOperationException("Sequence is empty.");
    
            if (comparer == null)
                comparer = Comparer<TProjected>.Default;
    
            int index = 0, maxIndex = 0;
            var maxProjection = selector(erator.Current);
    
            while (erator.MoveNext())
            {
                index++;
                var projectedItem = selector(erator.Current);
    
                if (comparer.Compare(projectedItem, maxProjection) > 0)
                {
                    maxIndex = index;
                    maxProjection = projectedItem;
                }
            }
            return maxIndex;
        }
    }
