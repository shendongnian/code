	public static IObservable<T> Syphon<T>(
		this IObservable<T> source,
		Func<T, bool> predicate,
		Action<T> action)
	{
		if (source == null) throw new ArgumentNullException("source");
		if (predicate == null) throw new ArgumentNullException("predicate");
		if (action == null) throw new ArgumentNullException("action");
		return Observable.Create<T>(o =>
			source.Subscribe(
				t =>
				{
					if (predicate(t))
					{
						action(t);
					}
					else
					{
						o.OnNext(t);
					}
				},
				ex =>
					o.OnError(ex),
				() =>
					o.OnCompleted()));
	}
