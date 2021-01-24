	Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
	EventLoopScheduler els = new EventLoopScheduler();
	
	els.Schedule(() => Console.WriteLine(Thread.CurrentThread.ManagedThreadId));
	
	IObservable<string> pings = Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(30), els).Select(x => "Ping!");
	IObservable<string> pongs = Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(20), els).Select(x => "Pong!");
	IObservable<string> pangs = Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(10), els).Select(x => "Pang!");
	IObservable<string> query = Observable.Merge(els, pings, pongs, pangs);
	IDisposable subscription = query.Subscribe(x => Console.WriteLine($"{x} ({Thread.CurrentThread.ManagedThreadId})"));
	Console.ReadLine();
	
	subscription.Dispose();
	els.Dispose();
