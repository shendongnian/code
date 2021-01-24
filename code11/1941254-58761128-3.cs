    public static List<T> DequeueAll<T>(this ConcurrentQueue<T> source)
    {
        var list = new List<T>();
        while (source.TryDequeue(out var item))
        {
            list.Add(item);
        }
        return list;
    }
