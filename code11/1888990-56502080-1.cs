    Random random = new Random(0);
    var list = Enumerable.Range(0, 10000).Select(_ => random.Next(0, 10000)).ToList();
    var enumerator = new ThreadSafeEnumerator<int>(list);
    var tasks = Enumerable.Range(0, 4).Select(_ => Task.Run(() =>
    {
        while (enumerator.MoveNext(out var current))
        {
            if (current.Value % 2 != 0) current.Remove();
        }
    })).ToArray();
    Task.WaitAll(tasks);
    Console.WriteLine($"Count: {list.Count}");
    Console.WriteLine($"Top Ten: {String.Join(", ", list.OrderBy(n => n).Take(10))}");
