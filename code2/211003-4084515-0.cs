    public static class IEnumerableExtensions
    {
        public static IEnumerable<TSource> PadIfFewerThan<TSource>(
            this IEnumerable<TSource> items,
            int size, TSource value = default(TSource))
        {
            return items.PadIfFewerThan(size, i => value);
        }
        public static IEnumerable<TSource> PadIfFewerThan<TSource>(
            this IEnumerable<TSource> items,
            int size, Func<int, TSource> generateItem)
        {
            int count = 0;
            foreach (var item in items)
            {
                ++count;
                yield return item;
            }
            foreach (var index in Enumerable.Range(count, size - count))
                yield return generateItem(index);
        }
    }
