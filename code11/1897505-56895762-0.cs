	Random _rdm = null;
	IDisposable _subscription = null;
	public void ThreadProc()
	{
		_rdm = new Random(100);
		_subscription =
			Observable
				.Interval(TimeSpan.FromSeconds(1.0))
				.Select(x => _rdm.Next().ToString())
				.Subscribe(x => Voyage = x);
	}
