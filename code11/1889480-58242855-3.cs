    public static async IAsyncEnumerable<TResult> ParallelEnumerateAsync<TResult>(
        this IEnumerable<Task<TResult>> coldTasks, int degreeOfParallelism)
    {
        if (degreeOfParallelism < 1)
            throw new ArgumentOutOfRangeException(nameof(degreeOfParallelism));
        foreach (var task in LagSafe(coldTasks, degreeOfParallelism - 1))
        {
            yield return await task.ConfigureAwait(false);
        }
        static IEnumerable<T> LagSafe<T>(IEnumerable<T> source, int count)
        {
            var queue = new Queue<T>();
            var locker = new object();
            using (var enumerator = source.GetEnumerator())
            {
                int index = 0;
                while (true)
                {
                    bool doYield = false; T itemToYield = default;
                    lock (locker)
                    {
                        if (!enumerator.MoveNext()) break;
                        queue.Enqueue(enumerator.Current);
                        index++;
                        if (index > count)
                        {
                            doYield = true; itemToYield = queue.Dequeue();
                        }
                    }
                    if (doYield) yield return itemToYield;
                }
            }
            while (true)
            {
                T itemToYield;
                lock (locker)
                {
                    if (queue.Count == 0) yield break;
                    itemToYield = queue.Dequeue();
                }
                yield return itemToYield;
            }
        }
    }
