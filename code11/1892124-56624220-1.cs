    public static class IEnumerableExtension
    {
        public static IEnumerable<IEnumerable<T>> InBatches<T>(this IEnumerable<T> enumerable, int batchSize)
        {
            var batch = new List<T>(batchSize);
            var i = 0;
            foreach (var item in enumerable)
            {
                batch.Add(item);
                if (++i == batchSize)
                {
                    // our batch is complete - yield return and create a new one
                    yield return batch;
                    batch = new List<T>(batchSize);
                    i = 0;
                }
            }
            // something left in batch
            if (i != 0)
                yield return batch;
        }
    }
