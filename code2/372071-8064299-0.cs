	public IObservable<Boolean> GettingUDPMessages(IPEndPoint localEP)
	{
		return Observable.Create<bool>(o =>
		{
			var subject = new AsyncSubject<bool>();
			return new CompositeDisposable(
				Observable.Amb(
					BaseComms
						.UDPBaseStringListener(localEP)
						.Where(msg => msg.Data.Contains("running"))
						.Select(s => true),
					Observable
						.Timer(TimeSpan.FromMilliseconds(10.0))
						.Select(_ => false)
				).Take(1).Subscribe(subject), subject.Subscribe(o));
		});
	}
