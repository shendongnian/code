        var bc = new BlockingCollection<int>();
    Task.Factory.StartNew(() =>
        {
            ParallelOptions options = new ParallelOptions
                {
                    MaxDegreeOfParallelism = 30
                };
            Parallel.ForEach(bc.GetConsumingEnumerable(), options, i => { });
        });
