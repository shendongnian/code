    public static IEnumerable<(T Previous, T Current, T Next)> WithPreviousAndNext<T>(
        this IEnumerable<T> source, T firstPrevious = default, T lastNext = default)
    {
        Queue<T> queue = new Queue<T>(2);
        queue.Enqueue(firstPrevious);
        foreach (var item in source)
        {
            if (queue.Count > 1)
            {
                yield return (queue.Dequeue(), queue.Peek(), item);
            }
            queue.Enqueue(item);
        }
        if (queue.Count > 1) yield return (queue.Dequeue(), queue.Peek(), lastNext);
    }
