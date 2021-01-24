    var list = new List<int> { 1 };
    var queue = new ConcurrentQueue<List<int>>();
    queue.Enqueue(list.ToList()); // enqueue a copy
    list.Clear();
    if (queue.TryDequeue(out var originalList))
        Console.WriteLine(originalList.Count);  // output 1
