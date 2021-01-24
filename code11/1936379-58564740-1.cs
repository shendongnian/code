    static IEnumerable<Stuff> GetLotsOfStuff(IEnumerable<int> ids)
    {
        var processor = new TransformBlock<int, Stuff>(async id =>
        {
            return await GetStuffById(id);
        }, new ExecutionDataflowBlockOptions
        {
            MaxDegreeOfParallelism = 5,
            BoundedCapacity = 50, // Avoid buffering millions of ids
        });
        var completionCTS = new CancellationTokenSource();
        var feederTask = Task.Run(async () =>
        {
            foreach (int id in ids)
            {
                if (completionCTS.IsCancellationRequested) break;
                await processor.SendAsync(id).ConfigureAwait(false);
            }
            processor.Complete();
        });
        try
        {
            while (processor.OutputAvailableAsync().Result)
            {
                while (processor.TryReceive(out var stuff))
                {
                    yield return stuff;
                }
            }
            feederTask.Wait(); // To propagate exceptions
            processor.Completion.Wait(); // To propagate exceptions
        }
        finally // This runs when the caller completes the enumeration
        {
            completionCTS.Cancel();
        }
    }
