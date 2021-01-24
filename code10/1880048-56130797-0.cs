    var records = new BlockingCollection<SomeRecord>();
    var outputs = new BlockingCollection<SomeResult>();
    var readRecords = Task.Run(async () =>
    {
        using (var conn = new SqlConnection("..."))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var record = new SomeRecord { Prop = reader.GetValue(0) };
                    records.Add(record);
                }
            }
        }
    });
    var transformRecords = Task.Run(() =>
    {
        foreach (var record in records.GetConsumingEnumerable())
        {
            // transform record
            outputs.Add(new SomeResult());
        }
    });
    var consumeResults = Task.Run(() =>
    {
        foreach (var result in outputs.GetConsumingEnumerable())
        {
            // ...
        }
    });
    Task.WaitAll(readRecords, transformRecords, consumeResults);
