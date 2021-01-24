    private static async Task DoSomethingAsync(IEnumerable<object> objects)
    {
        await Task.Run(() =>
        {
            long sum = 0; for (int i = 0; i < 500000000; i++) sum += i;
        }).ConfigureAwait(false);
    }
