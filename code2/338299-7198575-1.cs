    public IDisposable StartProcess<T>(Action<T> load, Action<T> post) where T : new()
	{
		return StartProcess(TimeSpan.FromSeconds(1), new T())
					.Do(load)
					.Subscribe(post);
	}
	
	private IObservable<long> StartProcess<T>(TimeSpan span, T obj) where T : new()
	{
		Observable
			.Interval(span)
			.OnErrorResumeNext(Observable.Defer(() => StartProcess(IncreaseSpan(span), obj)))
			.Concat(Observable.Defer(() => StartProcess(TimeSpan.FromSeconds(1), new T())));
	}
	
	private TimeSpan IncreaseSpan(TimeSpan span)
	{
		return TimeSpan.FromSeconds(span.TotalSeconds < 1800? span.TotalSeconds * 2 : 3600);
	}
