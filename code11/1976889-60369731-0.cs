	public IObservable<Price> Stream(Instrument instrumentDetails)
		=>
			Observable
				.FromAsync(() => _svc.GetSomeInitialPrice())
				.SelectMany(x =>
					_priceObserver
						.Stream
						.Where(o => o.Symbol == instrumentDetails.Symbol)
						.Select(o => GetPrice(o, instrumentDetails))
						.StartWith(x));
