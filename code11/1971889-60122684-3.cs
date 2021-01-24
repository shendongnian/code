	static void AddResultsToDb(IEnumerable<int> numbers)
	{
	    numbers 
	        .ToObservable()
	        .Select(n => Observable.Start(() => new { n, r = ComputeResult(n) }))
			.Merge(maxConcurrent: 2)
	        .Do(x => AddResultToDb(x.n, x.r))
			.Wait();
	}
