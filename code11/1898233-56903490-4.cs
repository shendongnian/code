    var buffer = new BlockingCollection<string>(boundedCapacity: 10);
    var producers = Enumerable.Range(0, 3)
    .Select(n => Task.Factory.StartNew(() =>
    {
        var random = new Random(n); // Non-random seed, same data on every run
        var sb = new StringBuilder();
        for (int i = 0; i < 10000; i++)
        {
            sb.Clear();
            for (int j = 0; j < 100; j++)
            {
                sb.AppendLine(random.Next().ToString());
            }
            buffer.Add(sb.ToString());
        }
    }, TaskCreationOptions.LongRunning))
    .ToArray();
    var allProducers = Task.WhenAll(producers).ContinueWith(_ =>
    {
        buffer.CompleteAdding();
    });
    // Consumer the same as previously (ommited)
    Task.WaitAll(allProducers, consumer);
