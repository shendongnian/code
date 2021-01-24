    public static async IAsyncEnumerable<T> EnumerateAndNotify<T>(
        Func<Task, IAsyncEnumerator<T>> enumeratorFactory)
    {
        var enumerationTCS = new TaskCompletionSource<bool>();
        try
        {
            var enumerator = enumeratorFactory(enumerationTCS.Task);
            await using (enumerator)
            {
                while (await enumerator.MoveNextAsync())
                {
                    yield return enumerator.Current;
                }
            }
        }
        finally
        {
            enumerationTCS.SetResult(true);
        }
    }
