    public static List<List<T>> ChunkBy<T>(this IEnumerable<T> source, Func<T, long> metric, long maxChunkSize)
    {
        return source
            .Aggregate(
                new
                {
                    Sum = 0L,
                    Current = (List<T>)null,
                    Result = new List<List<T>>()
                },
                (agg, item) =>
                {
                    var value = metric(item);
                    if (agg.Current == null || agg.Sum + value > maxChunkSize)
                    {
                        var current = new List<T> { item };
                        agg.Result.Add(current);
                        return new { Sum = value, Current = current, agg.Result };
                    }
    
                    agg.Current.Add(item);
                    return new { Sum = agg.Sum + value, agg.Current, agg.Result };
                })
            .Result;
    }
