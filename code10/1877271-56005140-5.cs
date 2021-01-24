    var getPages = Enumerable.Range(0, 10);
    var els1 = new EventLoopScheduler();
    var els2 = new EventLoopScheduler();
    var observable =
        getPages
            .ToObservable()
            .Publish(ps =>
                Observable
                    .Merge(
                        ps.SelectMany(p => Observable.Start(() => consume1(p), els1)),
                        ps.SelectMany(p => Observable.Start(() => consume2(p), els2))));
    observable.Wait();
	public void consume1(int p)
	{
		Console.WriteLine($"1:{p}");
		Thread.Sleep(200);
	}
	
	public void consume2(int p)
	{
		Console.WriteLine($"2:{p}");
		Thread.Sleep(100);
	}
