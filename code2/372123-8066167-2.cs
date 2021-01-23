    public static class Class1
        {
            public static IEnumerable<TResult> SelectAsync<TResult>(
                IEnumerable<TResult> producer1,
                IEnumerable<TResult> producer2,
                int capacity)
            {
            var resultsQueue = new BlockingCollection<TResult>(capacity);
            var producer1Done = false;
            var producer2Done = false;
            Task.Factory.StartNew(() =>
            {
                foreach (var product in producer1)
                {
                    resultsQueue.Add(product);
                }
                producer1Done = true;
                if (producer1Done && producer2Done) {resultsQueue.CompleteAdding();}
            });
            Task.Factory.StartNew(() =>
            {
                foreach (var product in producer2)
                {
                    resultsQueue.Add(product);
                }
                producer2Done = true;
                if (producer1Done && producer2Done) { resultsQueue.CompleteAdding(); }
            });
            return resultsQueue.GetConsumingEnumerable();
        }
        public static IEnumerable<TResult> SelectAsyncUnique<TResult>(this IEnumerable<TResult> source)
        {
            HashSet<TResult> knownResults = new HashSet<TResult>();
            foreach (TResult result in source)
            {
                if (!knownResults.Contains(result))
                {
                    yield return result;
                }
            }
        }
    }
