    public static async IAsyncEnumerable<TResult> ParallelEnumerateAsync<TResult>(
        this IEnumerable<Task<TResult>> coldTasks, int degreeOfParallelism)
    {
        if (degreeOfParallelism < 1)
            throw new ArgumentOutOfRangeException(nameof(degreeOfParallelism));
        var queue = new Queue<Task<TResult>>();
        var locker = new object();
        using (var enumerator = coldTasks.GetEnumerator())
        {
            int index = 0;
            while (true)
            {
                bool doYield = false; Task<TResult> taskToYield = null;
                lock (locker)
                {
                    if (!enumerator.MoveNext()) break;
                    queue.Enqueue(enumerator.Current);
                    index++;
                    if (index >= degreeOfParallelism)
                    {
                        doYield = true; taskToYield = queue.Dequeue();
                    }
                }
                if (doYield) yield return await taskToYield.ConfigureAwait(false);
            }
        }
        while (true)
        {
            Task<TResult> taskToYield;
            lock (locker)
            {
                if (queue.Count == 0) yield break;
                taskToYield = queue.Dequeue();
            }
            yield return await taskToYield.ConfigureAwait(false);
        }
    }
