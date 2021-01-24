    var queue = new ConcurrentQueue<Price>();
    var cts = new CancellationTokenSource();
    var producer = Task.Run(async () =>
    {
        try
        {
            var random = new Random();
            while (true)
            {
                queue.Enqueue(new Price
                {
                    Low = random.Next(0, 500),
                    High = random.Next(500, 1000)
                });
                await Task.Delay(millisecondsDelay: 1000, cts.Token);
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Producer Canceled");
        }
    });
    var consumer = Task.Run(async () =>
    {
        try
        {
            var random = new Random();
            while (true)
            {
                await Task.Delay(millisecondsDelay: 60000, cts.Token);
                var prices = queue.DequeueAll();
                Console.Write($"Minute Report");
                Console.Write($", Count: {prices.Count,2}");
                Console.Write($", Low Average: {prices.Average(p => p.Low):#,0.0000}");
                Console.Write($", High Average: {prices.Average(p => p.High):#,0.0000}");
                Console.WriteLine();
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Consumer Canceled");
        }
    });
    Console.WriteLine("Press Escape to finish.");
    while (true)
    {
        var keyInfo = Console.ReadKey(true);
        if (keyInfo.Key == ConsoleKey.Escape) break;
    }
    cts.Cancel();
    Task.WaitAll(producer, consumer);
