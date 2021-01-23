    [Test]
    public void ThreadNamesTest()
    {
        var rnd = new Random();
        var range = Enumerable.Range(0, 50);
        var rangeBack = new Dictionary<int, int>();
        var rangeBackLocker = new object();
        range.AsParallel().AsOrdered()
            .WithDegreeOfParallelism(4).ForAll(x =>
        {
            lock (rangeBackLocker)
            {
                rangeBack.Add(x, Thread.CurrentThread.ManagedThreadId);
            }
            Thread.Sleep(100 * rnd.Next(10));         
        });
        Assert.AreEqual(rangeBack.GroupBy(x=>x.Value).Count(), 4);
    }
