    void UpdateSql() {
        var batch = new List<Data>();
        foreach (var item in collection.GetConsumingEnumerable()) {
            batch.Add(item);
            if (batch.Count > SomeBatchSize) {
                InsertIntoSql(batch);
                batch.Clear();
            }
        }
        if (batch.Count > 0)
            InsertIntoSql(batch); // insert remaining items
    }
