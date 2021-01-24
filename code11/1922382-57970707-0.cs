    static async Task Main(string[] args)
    {
        var cancelTask = Task.CompletedTask;
        var task1 = Task.Run(async () =>
        {
            try
            {
                for (var i = 0; i < 20; i++)
                {
                    Console.WriteLine("Test pcb");
                    await Task.Delay(1000);
                    await cancelTask;
                }
            }
            catch
            {
                Console.WriteLine("I was stopped!");
            }
            finally
            {
                Console.WriteLine("End!");
            }
        });
        var task2 = Task.Run(async () =>
        {
            try
            {
                for (var i = 0; i < 30; i++)
                {
                    if (i == 5)
                    {
                        cancelTask = Task.FromException(new OperationCanceledException());
                    }
                    Console.WriteLine("Monitoring state");
                    await Task.Delay(1000);
                }
            }
            catch
            {
                throw new Exception("Help!");
            }
        });
        await Task.WhenAll(task1, task2);
    }
