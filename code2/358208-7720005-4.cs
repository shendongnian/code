	public static IObservable<T> Pausable<T>(
		this IObservable<T> source,
		IObservable<bool> pauser)
	{
		return Observable.Create<T>(o =>
		{
			var paused = new SerialDisposable();
			var subscription = Observable.Publish(source, ps =>
			{
				var values = new ReplaySubject<T>();
				Func<bool, IObservable<T>> switcher = b =>
				{
					if (b)
					{
						values.Dispose();
						values = new ReplaySubject<T>();
						paused.Disposable = ps.Subscribe(values);
						return Observable.Empty<T>();
					}
					else
					{
						return values.Concat(ps);
					}
				};
	
				return pauser.StartWith(false).DistinctUntilChanged()
					.Select(p => switcher(p))
					.Switch();
			}).Subscribe(o);
			return new CompositeDisposable(subscription, paused);
		});
	}
