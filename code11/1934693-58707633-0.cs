    public static async IAsyncEnumerable<T> ToAsyncEnumerable<T>(
        this IReceivableSourceBlock<T> source)
    {
        while (await source.OutputAvailableAsync().ConfigureAwait(false))
        {
            while (source.TryReceive(out T item))
            {
                yield return item;
            }
        }
    }
