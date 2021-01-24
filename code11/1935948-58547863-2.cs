    var enumerable = Enumerable.Range(0, 1_000_000);
    var cachedEnumerable = new CachedEnumerable<int>(enumerable);
    var enumerator = cachedEnumerable.GetEnumerator();
    var tasks = Enumerable.Range(1, 4).Select(id => Task.Run(() =>
    {
        int count = 0;
        while (enumerator.MoveNext())
        {
            count++;
        }
        Console.WriteLine($"Task #{id} count: {count}");
    })).ToArray();
    Task.WaitAll(tasks);
