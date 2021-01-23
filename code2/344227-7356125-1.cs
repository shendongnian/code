	Func<int, Func<int, int>, IObservable<int>> mkInts = (i0, fn) =>
		Observable.Create<int>(o =>
		{
			var ofn = Observable
				.FromAsyncPattern<int, int>(
					fn.BeginInvoke,
					fn.EndInvoke);
			
			var s = new Subject<int>();
			
			var q = s.Select(x => ofn(x)).Switch();
			
			var r = new CompositeDisposable(new IDisposable[]
			{
				q.Subscribe(s),
				s.Subscribe(o),
			});
			
			s.OnNext(i0);
			
			return r;
		});
