    var collection = BlockingCollection<Data>();
    var sqlinserter = Task.Factory.StartNew(UpdateSql());
    while (true) {
        Data statistics = FetchStatistics();
        if (statistics == null)
            break;
        collection.Add(statistics);
    }
    collection.CompleteAdding();
    sqlinserter.Wait();
    // -----
    void UpdateSql() {
        while (!collection.IsCompleted || collection.Count > 0) {
            var batch = new List<Data>();
            Data nextItem;
            while (collection.TryTake(out nextItem))
                batch.Add(nextItem);
        
            if (batch.Count > 0) {
                // batch insert into sql
            }
            // maybe do a short sleep
        }
    }
