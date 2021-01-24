    public static async IAsyncEnumerable<TResult> ParallelEnumerateAsync<TResult>(
        this IEnumerable<Task<TResult>> coldTasks, int degreeOfParallelism)
    {
        if (degreeOfParallelism < 1)
            throw new ArgumentOutOfRangeException(nameof(degreeOfParallelism));
        if (coldTasks is ICollection<Task<TResult>>) throw new ArgumentException(
            "The enumerable should not be materialized.", nameof(coldTasks));
        foreach (var task in Safe(Lag(coldTasks, degreeOfParallelism - 1)))
        {
            yield return await task.ConfigureAwait(false);
        }
        static IEnumerable<T> Lag<T>(IEnumerable<T> source, int count)
        {
            var queue = new Queue<T>();
            using (var enumerator = source.GetEnumerator())
            {
                int index = 0;
                while (enumerator.MoveNext())
                {
                    queue.Enqueue(enumerator.Current);
                    index++;
                    if (index > count) yield return queue.Dequeue();
                }
            }
            while (queue.Count > 0) yield return queue.Dequeue();
        }
        static IEnumerable<T> Safe<T>(IEnumerable<T> source)
        {
            var locker = new object();
            using (var enumerator = source.GetEnumerator())
            {
                while (true)
                {
                    T item;
                    lock (locker)
                    {
                        if (!enumerator.MoveNext()) yield break;
                        item = enumerator.Current;
                    }
                    yield return item;
                }
            }
        }
    }
