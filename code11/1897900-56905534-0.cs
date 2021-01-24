	public static IObservable<int> GetFrequency<T>(this IObservable<T> source, TimeSpan measuringFreq, TimeSpan lookback)
	{
		return source.GetFrequency(measuringFreq, lookback, Scheduler.Default);
	}
	
	public static IObservable<int> GetFrequency<T>(this IObservable<T> source, TimeSpan measuringFreq, TimeSpan lookback, IScheduler scheduler)
	{
		var recentMessages = source
			.Select(_ => Unit.Default)
			.Timestamp()
			.Scan(ImmutableList<Timestamped<Unit>>.Empty, (messages, t) => messages.Add(t).Where(m => m.Timestamp + lookback >= scheduler.Now).ToImmutableList());
		var timer = Observable.Timer(lookback, measuringFreq);
		
		var toReturn = timer
			.WithLatestFrom(recentMessages.StartWith(ImmutableList<Timestamped<Unit>>.Empty), (_, list) => list)
			.Select(list => list.Where(m => m.Timestamp + lookback >= scheduler.Now).Count());
			
		return toReturn;
	}
