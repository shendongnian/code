    public static IEnumerable<T> IgnoreLast<T>(this IEnumerable<T> source, int ignoreCount)
    {
        if (ignoreCount < 0)
        {
            throw new ArgumentOutOfRangeException("ignoreCount");
        }
        var buffer = new Queue<T>();
        foreach (T value in source)
        {
            if (buffer.Count < ignoreCount)
            {
                buffer.Enqueue(value);
                continue;
            }
    
            T buffered = buffer.Dequeue();
    
            buffer.Enqueue(value);
    
            yield return buffered;
        }
    }
