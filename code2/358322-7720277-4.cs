	IObservable<Guid> idUpdate = ...
	IObservable<bool> queryStateUpdate = ...
	var replay = new ReplaySubject<Guid>(1);
	var disposer = new SerialDisposable();
	Func<bool, IObservable<bool>, IObservable<Guid>,
		IObservable<Guid>> getSwitch = (qsu, qsus, iu) =>
	{
		if (qsu)
		{
			return replay.Merge(iu);
		}
		else
		{
			replay.Dispose();
			replay = new ReplaySubject<Guid>(1);
			disposer.Disposable = iu.TakeUntil(qsus).Subscribe(replay);
			return Observable.Empty<Guid>();
		}
	};
	
	var query =
		queryStateUpdate
			.DistinctUntilChanged()
			.Publish(qsus =>
				idUpdate
				.Publish(ius =>
					qsus
						.Select(qsu =>
							getSwitch(qsu, qsus, ius))))
			.Switch();
