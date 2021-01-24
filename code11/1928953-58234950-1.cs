    public static async IAsyncEnumerable<T> WithEnforcedCancellation<T>(
        this IAsyncEnumerable<T> source, CancellationToken cancellationToken)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));
        cancellationToken.ThrowIfCancellationRequested();
        await foreach (var item in source)
        {
            cancellationToken.ThrowIfCancellationRequested();
            yield return item;
        }
    }
