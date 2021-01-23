	public static IObservable<T> Pausable<T>(
		this IObservable<T> source,
		IObservable<bool> pauser)
	{
		return Observable.Create<T>(o =>
		{
			var paused = new SerialDisposable();
			var subscription = Observable.Publish(source, ps =>
			{
				var values = new List<T>();
				Func<bool, IObservable<T>> switcher = b =>
				{
					if (b)
					{
						paused.Disposable = ps.Subscribe(t =>
						{
							lock (values)
							{
								values.Add(t);
							}
						});
						return Observable.Empty<T>();
					}
					else
					{
						paused.Disposable = Disposable.Empty;
						var vs = (T[])null;
						lock (values)
						{
							vs = values.ToArray();
							values.Clear();
						}
						return vs.ToObservable().Concat(ps);
					}
				};
				
				return pauser.StartWith(false).Select(p => switcher(p)).Switch();
			}).Subscribe(o);
			return new CompositeDisposable(subscription, paused);
		});
	}
