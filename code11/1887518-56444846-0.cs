public async Task CancelAsync()
{
    if (cts != null && !cts.IsCancellationRequested)
    {
        cts.Cancel();
        await Task.WhenAll(tasks);
    }
}
await CancelAsync();
