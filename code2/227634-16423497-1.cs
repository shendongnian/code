    IObservable<SizeChangedEventArgs> ObservableSizeChanges = Observable
        .FromEventPattern<SizeChangedEventArgs>(this, "SizeChanged")
    	.Select(x => x.EventArgs)
    	.Throttle(TimeSpan.FromMilliseconds(200));
    IDisposable SizeChangedSubscription = ObservableSizeChanges
		.ObserveOn(SynchronizationContext.Current)
		.Subscribe(x => {
			Size_Changed(x);
		});
