    var collection = new BlockingCollection<Data>();
    var sqlinserter = Task.Factory.StartNew(UpdateSql());
    while (true) {
        Data statistics = FetchStatistics();
        if (statistics == null)
            break;
        collection.Add(statistics);
    }
    collection.CompleteAdding();
    sqlinserter.Wait();
