    public static class EnumerableExt
    {
        public sealed class Batch<T>
        {
            public readonly int            Index;
            public readonly IEnumerable<T> Items;
            public Batch(int index, IEnumerable<T> items)
            {
                Index = index;
                Items = items;
            }
        }
        // Note: Not threadsafe, so not suitable for use with Parallel.Foreach() or IEnumerable.AsParallel()
        public static IEnumerable<Batch<T>> Partition<T>(this IEnumerable<T> input, int batchSize)
        {
            var enumerator = input.GetEnumerator();
            int index      = 0;
            while (enumerator.MoveNext())
                yield return new Batch<T>(index++, nextBatch(enumerator, batchSize));
        }
        private static IEnumerable<T> nextBatch<T>(IEnumerator<T> enumerator, int blockSize)
        {
            do { yield return enumerator.Current; }
            while (--blockSize > 0 && enumerator.MoveNext());
        }
    }
