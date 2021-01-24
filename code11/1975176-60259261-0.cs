    /// <summary>
    /// Starts all inner IAsyncEnumerable and returns items from all of them in order in which they come.
    /// </summary>
    public static async IAsyncEnumerable<TItem> SelectManyAsync<TItem>(IEnumerable<IAsyncEnumerable<TItem>> source)
    {
        // get enumerators from all inner IAsyncEnumerable
        var enumerators = source.Select(x => x.GetAsyncEnumerator()).ToList();
        List<Task<(IAsyncEnumerator<TItem>, bool)>> runningTasks = new List<Task<(IAsyncEnumerator<TItem>, bool)>>();
        // start all inner IAsyncEnumerable
        foreach (var asyncEnumerator in enumerators)
        {
            runningTasks.Add(MoveNextWrapped(asyncEnumerator));
        }
        // while there are any running tasks
        while (runningTasks.Any())
        {
            // get next finished task and remove it from list
            var finishedTask = await Task.WhenAny(runningTasks);
            runningTasks.Remove(finishedTask);
            // get result from finished IAsyncEnumerable
            var result = await finishedTask;
            var asyncEnumerator = result.Item1;
            var hasItem = result.Item2;
            // if IAsyncEnumerable has item, return it and put it back as running for next item
            if (hasItem)
            {
                yield return asyncEnumerator.Current;
                runningTasks.Add(MoveNextWrapped(asyncEnumerator));
            }
        }
        // don't forget to dispose, should be in finally
        foreach (var asyncEnumerator in enumerators)
        {
            await asyncEnumerator.DisposeAsync();
        }
    }
    /// <summary>
    /// Helper method that returns Task with tuple of IAsyncEnumerable and it's result of MoveNextAsync.
    /// </summary>
    private static async Task<(IAsyncEnumerator<TItem>, bool)> MoveNextWrapped<TItem>(IAsyncEnumerator<TItem> asyncEnumerator)
    {
        var res = await asyncEnumerator.MoveNextAsync();
        return (asyncEnumerator, res);
    }
