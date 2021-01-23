    public class OrderSumPair<TResult>
    {
        public int Order { get; set;}
        public TResult Value { get; set; }
    }
    public static IEnumerable<OrderSumPair<TResult>> Rollup<TSource, TKey, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        TResult seed,
        Func<TSource, TResult, TResult> projection)
        {
            if (!source.Any())
            {
                yield break;
            }
            TSource[] ordered = source.OrderBy(keySelector).ToArray();
            TKey previous = keySelector(ordered[0]);
            int count = 1;
            TResult nextSeed = seed;
            foreach (TSource src in source)
            {
                TKey current = keySelector(src);
                if (!current.Equals(previous))
                {
                    nextSeed = seed;
                    count = 1;
                }
                TResult projectedValue = projection(src, nextSeed);
                nextSeed = projectedValue;
                yield return new OrderSumPair<TResult> { Order = count, Value = projectedValue };
                previous = current;
                count++;
            }
        }
