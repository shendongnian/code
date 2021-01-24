    static TResult GetNewestOrDefault<TSource, TResult>(this IEnumerable<TSource> source,
       Func<Tsource, DateTime> dateSelector)
    {
        var enumerator = source.GetEnumerator();
        if (enumerator.MoveNext())
        {   // at least one element; initialize newest:
            TSource newestElement = enumerator.Current;
            DateTime newestDate = dateSelector(newest);
            // scan the rest of the sequence and check if newer:
            while (enumerator.MoveNext())
            {
                Tsource nextElement = enumerator.Current;
                Datetime nextDate = dateSelector(nextElement);
                // if next element has a newer date, remember it as newest:
                if (newestDate < nextDate
                {
                    newestElement = nextElement;
                    newestDate = nextDate,
                }
            }
            // scanned all elements exactly once
            return newestElement;
        }
        else
           // empty sequence, return default
           return default(TResult);
    }
