	var subject = new Subject<uint>();
	var observable = subject.GroupBy(t => t % 10)
		.Select(t => t.Replay(1).RefCount()).Replay().RefCount();
	// dummy subscriptions required for Replay to work correctly.
	var dummySub = new CompositeDisposable();
	dummySub.Add(observable.Subscribe(o => dummySub.Add(o.Subscribe())));
	observable
		.Select(o => o.Select((t, index) => (t.Key, t.num, index)))
		.Merge()
		.Subscribe(t =>
		{
			if (t.index == 0)
				Console.WriteLine($"[1] - FIRST: {t.num}");
			else
				Console.WriteLine($"[1] - UPDATE: {t.num}");
		});
	subject.OnNext(15);
	observable
		.Select(o => o.Select((t, index) => (t.Key, t.num, index)))
		.Merge()
		.Subscribe(t =>
		{
			if (t.index == 0)
				Console.WriteLine($"[1] - FIRST: {t.num}");
			else
				Console.WriteLine($"[1] - UPDATE: {t.num}");
		});
	subject.OnNext(25);
	observable
		.Select(o => o.Select((t, index) => (t.Key, t.num, index)))
		.Merge()
		.Subscribe(t =>
		{
			if (t.index == 0)
				Console.WriteLine($"[1] - FIRST: {t.num}");
			else
				Console.WriteLine($"[1] - UPDATE: {t.num}");
		});
