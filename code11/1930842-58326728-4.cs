	TestScheduler ts = new TestScheduler();
	var source = ts.CreateHotObservable<string>(
		new Recorded<Notification<string>>(200.MsTicks(), Notification.CreateOnNext("A1")),
		new Recorded<Notification<string>>(300.MsTicks(), Notification.CreateOnNext("A2")),
		new Recorded<Notification<string>>(500.MsTicks(), Notification.CreateOnNext("B1")),
		new Recorded<Notification<string>>(800.MsTicks(), Notification.CreateOnNext("B2"))
	);
	var comparer = new FirstLetterComparer();
	var target = source
		.ThrottleBy4(s => s, TimeSpan.FromSeconds(1), comparer: comparer, scheduler: ts);
	var expectedResults = ts.CreateHotObservable<string>(
		new Recorded<Notification<string>>(500.MsTicks(), Notification.CreateOnNext("A2")),
		new Recorded<Notification<string>>(1800.MsTicks(), Notification.CreateOnNext("B2"))
	);
	var observer = ts.CreateObserver<string>();
	target.Subscribe(observer);
	ts.Start();
	ReactiveAssert.AreElementsEqual(expectedResults.Messages, observer.Messages);
