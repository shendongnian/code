    var producer = Task.Run(async () =>
    {
        for (int i = 1; i <= 10; i++)
        {
            await Task.Delay(100);
            Console.WriteLine($"Sending {i}");
            await block.SendAsync(Task.Delay(i * 100));
        }
        block.Complete();
    });
