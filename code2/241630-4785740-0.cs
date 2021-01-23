    int collSize = 1000000;
    var bag1 = new ConcurrentBag<int>();
    var stopWatch = new Stopwatch.StartNew();
    Task.WaitAll(Enumerable.Range(1, collSize).Select(x => Task.Factory.StartNew(() =>
    {
        bag1.Add(x);
    })).ToArray());
    stopWatch.Stop();
    Console.WriteLine("Elapsed = {0}", stopWatch.Elapsed.TotalSeconds);
 
