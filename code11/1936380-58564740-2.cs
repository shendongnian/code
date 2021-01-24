    public static IEnumerable<TResult> Transform<TSource, TResult>(
        IEnumerable<TSource> source, Func<TSource, Task<TResult>> taskFactory,
        int degreeOfConcurrency)
    {
        var processor = new TransformBlock<TSource, TResult>(async item =>
        {
            return await taskFactory(item);
        }, new ExecutionDataflowBlockOptions
        {
            MaxDegreeOfParallelism = degreeOfConcurrency
        });
        var paddedSource = source.Select(item => (item, true))
            .Concat(Enumerable.Repeat((default(TSource), false), degreeOfConcurrency));
        int index = -1;
        bool completed = false;
        foreach (var (item, hasValue) in paddedSource)
        {
            index++;
            if (hasValue) { processor.Post(item); }
            else if (!completed) { processor.Complete(); completed = true; }
            if (index >= degreeOfConcurrency)
            {
                if (!processor.OutputAvailableAsync().Result) break; // Blocking call
                if (!processor.TryReceive(out var result))
                    throw new InvalidOperationException(); // Should never happen
                yield return result;
            }
        }
        processor.Completion.Wait();
    }
