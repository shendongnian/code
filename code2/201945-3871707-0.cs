    int batchSize = 100;
    var batched = yourCollection.Select((x, i) => new { Val = x, Idx = i })
                                .GroupBy(x => x.Idx / batchSize,
                                         (k, g) => g.Select(x => x.Val));
    // and then to demonstrate...
    foreach (var batch in batched)
    {
        Console.WriteLine("Processing batch...");
        foreach (var item in batch)
        {
            Console.WriteLine("Processing item: " + item);
        }
    }
