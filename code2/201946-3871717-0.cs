    public static void Batch<T>(this IEnumerable<T> items, int batchSize, Action<IEnumerable<T>> batchAction)
    {
        if (batchSize < 1) throw new ArgumentException();
        
        List<T> buffer = new List<T>();
        using (var enumerator = (items ?? Enumerable.Empty<T>()).GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                buffer.Add(enumerator.Current);
                if (buffer.Count == batchSize)
                {
                    batchAction(buffer);
                    buffer.Clear();
                }
            }
    
            //execute for remaining items
            if (buffer.Count > 0)
            {
                batchAction(buffer);
            }
        }
    }
