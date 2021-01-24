    private static IAsyncEnumerable<(string Url, bool IsValid)> ValidateUrls(
        this IAsyncEnumerable<string> urls)
    {
        return EnumerateAndNotify(GetEnumerator);
        async IAsyncEnumerator<(string Url, bool IsValid)> GetEnumerator(
            Task callerEnumeration)
        {
            var buffer = new System.Threading.Tasks.Dataflow.BufferBlock<string>();
            _ = Task.Run(async () =>
            {
                await foreach (var url in urls)
                {
                    if (callerEnumeration.IsCompleted) break;
                    Console.WriteLine($"Url {url} received");
                    await buffer.SendAsync(url);
                }
                buffer.Complete();
            });
            while (await buffer.OutputAvailableAsync() && buffer.TryReceive(out var url))
            {
                yield return (url, await MockValidateUrl(url));
            }
        }
    }
