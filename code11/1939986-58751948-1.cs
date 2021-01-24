    public static async Task<List<T>> ToListAsync<T>(this IReceivableSourceBlock<T> block,
        CancellationToken cancellationToken = default)
    {
        var list = new List<T>();
        while (await block.OutputAvailableAsync(cancellationToken).ConfigureAwait(false))
        {
            while (block.TryReceive(out var item))
            {
                list.Add(item);
            }
        }
        return list;
    }
