    static async Task Main()
    {
        // Start all three tasks
        Task t1 = FetchSlowAsync();
        Task t2 = FetchBingAsync();
        Task t3 = FetchAsync();
        // Then wait for them all to finish
        await Task.WhenAll(t1, t2, t3);
        
        await Console.Out.WriteLineAsync("All done!");
    }
