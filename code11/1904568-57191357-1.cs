    [Test]
    public async Task DoSomething()
    {
        var sw = Stopwatch.StartNew();
        var list = Enumerable.Range(0, 10).ToList();
        foreach(var x in list)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
        Console.WriteLine($"{sw.ElapsedMilliseconds}ms");
    }
