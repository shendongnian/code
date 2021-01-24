    public static async IAsyncEnumerable<TResult> WhenEach<TResult>(Task<TResult>[] tasks)
    {
        foreach (var bucket in Interleaved(tasks))
        {
            var t = await bucket;
            yield return await t;
        }
    }
