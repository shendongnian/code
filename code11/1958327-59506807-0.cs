    using System.Runtime.CompilerServices;
    public static async IAsyncEnumerable<TSource[]> Zip<TSource>(
        IEnumerable<IAsyncEnumerable<TSource>> sources,
        [EnumeratorCancellation]CancellationToken cancellationToken = default)
    {
        var enumerators = sources.Select(x => x.GetAsyncEnumerator()).ToArray();
        try
        {
            while (true)
            {
                var array = new TSource[enumerators.Length];
                for (int i = 0; i < enumerators.Length; i++)
                {
                    if (!await enumerators[i].MoveNextAsync(cancellationToken)) yield break;
                    array[i] = enumerators[i].Current;
                }
                yield return array;
            }
        }
        finally
        {
            foreach (var enumerator in enumerators)
            {
                await enumerator.DisposeAsync();
            }
        }
    }
