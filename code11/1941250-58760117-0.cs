    var produced = new BlockingCollection<Price>();
    var producer = Task.Run(async () =>
    {
        try
        {
            var random = new Random();
            while (true)
            {
                produced.Add(new Price { Low = random.Next(500), High = random.Next(500, 1000) });
                await Task.Delay(1000);
            }
        }
        finally
        {
            produced.CompleteAdding();
        }
    });
    var consumer = Task.Run(async () =>
    {
        const int interval = 60; // seconds
        var values = new List<Price>();
        foreach (var value in produced.GetConsumingEnumerable())
        {
            values.Add(value);
            if (DateTime.UtcNow.Second % interval == 0)
            {
                Console.WriteLine(values.Average(p => p.High)); // do some work
                values.Clear();
            }
        }
    });
    Task.WaitAll(producer, consumer);
