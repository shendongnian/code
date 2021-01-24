    private static void ActionBlockTest(int sendDelay, int processDelay)
    {
        Console.WriteLine($"SendDelay: {sendDelay}, ProcessDelay: {processDelay}");
        var asyncLocal = new AsyncLocal<int>();
        var actionBlock = new ActionBlock<int>(async i =>
        {
            await Task.Delay(processDelay);
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
