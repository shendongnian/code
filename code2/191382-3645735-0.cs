    /// <summary>
    /// Enumerates the items of this collection, skipping the last
    /// <paramref name="count"/> items. Note that the memory usage of this method
    /// is proportional to <paramref name="count"/>, but the source collection is
    /// only enumerated once, and in a lazy fashion. Also, enumerating the first
    /// item will take longer than enumerating subsequent items.
    /// </summary>
    public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> source, int count)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        if (count < 0)
            throw new ArgumentOutOfRangeException("count",
                "count cannot be negative.");
        if (count == 0)
            return source;
        return skipLastIterator(source, count);
    }
    private static IEnumerable<T> skipLastIterator<T>(IEnumerable<T> source,
        int count)
    {
        var queue = new T[count];
        int headtail = 0; // tail while we're still collecting, both head & tail
                          // afterwards because the queue becomes completely full
        int collected = 0;
        foreach (var item in source)
        {
            if (collected < count)
            {
                queue[headtail] = item;
                headtail++;
                collected++;
            }
            else
            {
                if (headtail == count) headtail = 0;
                yield return queue[headtail];
                queue[headtail] = item;
                headtail++;
            }
        }
    }
    /// <summary>
    /// Returns a collection containing only the last <paramref name="count"/>
    /// items of the input collection. This method enumerates the entire
    /// collection to the end once before returning. Note also that the memory
    /// usage of this method is proportional to <paramref name="count"/>.
    /// </summary>
    public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int count)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        if (count < 0)
            throw new ArgumentOutOfRangeException("count",
                "count cannot be negative.");
        if (count == 0)
            return new T[0];
        var queue = new Queue<T>(count + 1);
        foreach (var item in source)
        {
            if (queue.Count == count)
                queue.Dequeue();
            queue.Enqueue(item);
        }
        return queue.AsEnumerable();
    }
