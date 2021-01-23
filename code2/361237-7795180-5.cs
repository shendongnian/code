	public static IObservable<T> Syphon<T>(
		this IObservable<T> source,
		out Func<Func<T, bool>, Action<T>, IDisposable> subscriber)
	{
		if (source == null) throw new ArgumentNullException("source");
		var pas = new List<Tuple<Func<T, bool>, Action<T>>>();
		
		subscriber = (p, a) =>
		{
			lock (pas)
			{
				var tuple = Tuple.Create(p, a);
				pas.Add(tuple);
				return Disposable.Create(() =>
				{
					lock (pas)
					{
						pas.Remove(tuple);
					}
				});
			}
		};
		
		return Observable.Create<T>(o =>
			source.Subscribe(
				t =>
				{
					Action<T> a = null;
					lock (pas)
					{
						var pa = pas.FirstOrDefault(x => x.Item1(t));
						if (pa != null)
						{
							a = pa.Item2;
						}
					}
					if (a != null)
					{
						a(t);
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
