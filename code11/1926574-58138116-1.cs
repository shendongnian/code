    // Create the block
    var cts = new CancellationTokenSource(2000); // Cancel after 2000 msec
    var block = new ActionTaskBlock<int, int>((item, token) =>
    {
        Console.WriteLine($"Start processing {item}");
        Task.WhenAny(Task.Delay(1000, token)).Wait(); // Sleep safely for 1000 msec
        token.ThrowIfCancellationRequested();
        return item * 2;
    }, cts.Token, maxDegreeOfParallelism: 2); // Process no more than 2 at a time
    // Feed the block with one request every 300 msec
    foreach (var i in Enumerable.Range(1, 10))
    {
        Console.WriteLine($"Scheduling {i}");
        block.ProcessAsync(i).ContinueWith(t =>
        {
            Console.WriteLine($"Item {i} processed with status {t.Status}");
        });
        Thread.Sleep(300);
        if (cts.IsCancellationRequested) break;
    }
    block.Complete();
    // Wait for the completion of all requests, or the cancellation of the token
    Task.WhenAny(block.Completion).Wait(); // Safe waiting (doesn't throw)
    Console.WriteLine($"The block finished with status {block.Completion.Status}");
