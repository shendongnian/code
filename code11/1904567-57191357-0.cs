    [Test]
    public void DoSomething()
    {
        var sw = Stopwatch.StartNew();
        var list = Enumerable.Range(0, 10).ToList();
        list.ForEach(async x => await Task.Delay(TimeSpan.FromSeconds(1)));
        Console.WriteLine($"{sw.ElapsedMilliseconds}ms");
    }
