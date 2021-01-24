    public async static IAsyncEnumerable<TResult> AwaitResults<TResult>(
        this IAsyncEnumerable<Task<TResult>> source,
        int concurrencyLevel = 1,
        [EnumeratorCancellation]CancellationToken cancellationToken = default)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (concurrencyLevel < 1)
            throw new ArgumentOutOfRangeException(nameof(concurrencyLevel));
        var semaphore = new SemaphoreSlim(concurrencyLevel);
        var channelCapacity = Math.Max(1000, concurrencyLevel * 10);
        var tasksChannel = Channel.CreateBounded<Task<TResult>>(channelCapacity);
        var completionCts = new CancellationTokenSource();
        // Feeder task: fire and forget
        _ = Task.Run(async () =>
        {
            try
            {
                using var linkedTokenSource = CancellationTokenSource
                    .CreateLinkedTokenSource(cancellationToken, completionCts.Token);
                await using var enumerator = source
                    .GetAsyncEnumerator(linkedTokenSource.Token);
                while (true)
                {
                    await semaphore.WaitAsync(linkedTokenSource.Token)
                        .ConfigureAwait(false);
                    if (!await enumerator.MoveNextAsync(linkedTokenSource.Token)
                        .ConfigureAwait(false)) break;
                    var task = enumerator.Current;
                    await tasksChannel.Writer.WriteAsync(task, linkedTokenSource.Token)
                        .ConfigureAwait(false);
                    HandleTaskCompletion(task);
                }
                tasksChannel.Writer.Complete();
            }
            catch (Exception ex)
            {
                tasksChannel.Writer.Complete(ex);
            }
        });
        async void HandleTaskCompletion(Task task)
        {
            try
            {
                await task.ConfigureAwait(false);
            }
            catch
            {
                // Ignore exceptions here
            }
            finally
            {
                semaphore.Release();
            }
        }
        try
        {
            while (await tasksChannel.Reader.WaitToReadAsync().ConfigureAwait(false))
            {
                while (tasksChannel.Reader.TryRead(out var task))
                {
                    yield return await task.ConfigureAwait(false);
                }
            }
        }
        finally // Happens when the caller disposes the output enumerator
        {
            completionCts.Cancel();
        }
    }
