    private static ConcurrentDictionary<int, int> dict = new ConcurrentDictionary<int, int>();
    private static void RemoveItems(Func<int, bool> condition)
    {
        int temp;
        foreach (var item in dict)
        {
            if (condition.Invoke(item.Value)) dict.TryRemove(item.Key, out temp);
        }
    }
    private static void Main()
    {
        Random r = new Random();
        // Start with a list of random integers ranging in value from 1 to 100
        var list = Enumerable.Range(0, 100).Select(x => r.Next(1, 101)).ToList();
        // Add our items to a concurrent dictionary
        for (int i = 0; i < list.Count; i++) dict.TryAdd(i, list[i]);
        // Start 5 tasks where each one removes items based on a
        // different (yet overlapping in many cases) condition
        var tasks = new[]
        {
            Task.Factory.StartNew(() => RemoveItems(i => i % 15 == 0)),
            Task.Factory.StartNew(() => RemoveItems(i => i % 10 == 0)),
            Task.Factory.StartNew(() => RemoveItems(i => i % 5 == 0)),
            Task.Factory.StartNew(() => RemoveItems(i => i % 3 == 0)),
            Task.Factory.StartNew(() => RemoveItems(i => i % 2 == 0)),
        };
        // Wait for tasks
        Task.WaitAll(tasks);
        // Reassign our list to the remaining values
        list = dict.Values.ToList();
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
