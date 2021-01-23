    public static class EnumerableSlicing
    {
    
        private class Status
        {
            public bool EndOfSequence;
        }
    
        private static IEnumerable<T> TakeOnEnumerator<T>(IEnumerator<T> enumerator, int count, 
            Status status)
        {
            while (--count > 0 && (enumerator.MoveNext() || !(status.EndOfSequence = true)))
            {
                yield return enumerator.Current;
            }
        }
    
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> items, int chunkSize)
        {
            if (chunkSize < 1)
            {
                throw new ArgumentException("Slices should not be smaller than 1 element");
            }
            var status = new Status { EndOfSequence = false };
            using (var enumerator = items.GetEnumerator())
            {
                while (!status.EndOfSequence)
                {
                    yield return TakeOnEnumerator(enumerator, chunkSize, status);
                }
            }
        }
    }
