    public static async IAsyncEnumerable<T> ToAsyncEnumerable<T>(
        this IReceivableSourceBlock<T> source,
        [EnumeratorCancellation]CancellationToken cancellationToken = default)
    {
        while (await source.OutputAvailableAsync(cancellationToken).ConfigureAwait(false))
        {
            while (source.TryReceive(out T item))
            {
                yield return item;
            }
        }
    }
