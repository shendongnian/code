    var population = Task.Factory.Start(Populate);
    var processing = Task.Factory.Start(Dequeue);
    await Task.WhenAll(population, processing);
    Task Populate()
    {
        foreach (...)
            collection.Add(...);
        collection.CompleteAdding();
    }
    Task Dequeue
    {
        while(!collection.IsComplete)
            await collection.Take();                         //consider using TryTake()
    }
