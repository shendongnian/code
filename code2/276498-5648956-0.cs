    string[] array = new string[] { "A", "2A", "3A", "4A", "5A", "6A", "7A", "8A", "9A", "10A" };
                System.Collections.Concurrent.ConcurrentDictionary<long, object> results = new System.Collections.Concurrent.ConcurrentDictionary<long, object>();
                Parallel.ForEach(array, (item, state, i) =>
                {
                    object result = ProcessItem(item);
                    results[i] = result;
                });
    
                foreach (var result in results.OrderBy(r => r.Key))
                    Trace.WriteLine(result);
