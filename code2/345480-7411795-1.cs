	Func<Uri, IObservable<string>> getJasonObsFunc = u =>
		Observable
			.FromAsyncPattern<Uri, string>(
				getJason.BeginInvoke,
				getJason.EndInvoke)
			.Invoke(u)
			.ObserveOn(Scheduler.TaskPool);
		
	Func<string, IObservable<Uri>> getUrisObsFunc = j =>
		Observable
			.FromAsyncPattern<string, IEnumerable<Uri>>(
				getUris.BeginInvoke,
				getUris.EndInvoke)
			.Invoke(j)
			.ObserveOn(Scheduler.TaskPool)
			.SelectMany(xs => xs.ToObservable());
