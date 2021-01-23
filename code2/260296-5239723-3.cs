    public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> list, int batchSize)
            {
    
                var batch = new List<T>(batchSize);
    
                foreach (var item in list)
                {
                    batch.Add(item);
                    if (batch.Count == batchSize)
                    {
                        yield return batch;
                        batch = new List<T>(batchSize);
                    }
                }
    
                if (batch.Count > 0)
                    yield return batch;
            }
