    private static void ActionBlockTest(int sendDelay, int actionDelay)
    {
        Console.WriteLine($"SendDelay: {sendDelay}, ActionDelay: {actionDelay}");
        var asyncLocal = new AsyncLocal<int>();
        var actionBlock = new ActionBlock<int>(async i =>
        {
            await Task.Delay(actionDelay);
            Console.WriteLine($"Processed {i}, Context: {asyncLocal.Value}");
        });
        Task.Run(async () =>
        {
            foreach (var i in Enumerable.Range(1, 5))
            {
                asyncLocal.Value = i;
                await actionBlock.SendAsync(i);
                await Task.Delay(sendDelay);
            }
        }).Wait();
        actionBlock.Complete();
        actionBlock.Completion.Wait();
    }
