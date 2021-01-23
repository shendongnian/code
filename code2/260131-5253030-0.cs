    var rootSubject = new ReplaySubject<Types>();
	var firstSubject = rootSubject.Where(x => x == Types.First);
	var secondSubject = rootSubject.Where(x => x == Types.Second);
	var thirdSubject = rootSubject.Where(x => x == Types.Third);
	var forthSubject = rootSubject.Where(x => x == Types.Fourth);
	var mergedSubject = Observable
		          .Merge(firstSubject, secondSubject, thirdSubject, forthSubject)
			.Timeout(TimeSpan.FromSeconds(2), Observable.Return(Types.Error))    
			.Replay();
	
	mergedSubject.Connect();
	
	rootSubject.OnNext(Types.First);
	rootSubject.OnNext(Types.Second);
	
	var result = mergedSubject.First();
	
	rootSubject.OnNext(Types.Third);
	rootSubject.OnNext(Types.Fourth);
	
	Console.WriteLine(String.Format("result - {0}", result));
