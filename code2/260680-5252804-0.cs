    var rootSubject = new Subject<Types>();
	var firstSubject = rootSubject.Where(x => x == Types.First);
	var secondSubject = rootSubject.Where(x => x == Types.Second);
	var thirdSubject = rootSubject.Where(x => x == Types.Third);
	var forthSubject = rootSubject.Where(x => x == Types.Fourth);
	var mergedSubject = 
		Observable.Merge(firstSubject, secondSubject, thirdSubject, forthSubject)  
		.Timeout(TimeSpan.FromSeconds(2), Observable.Return(Types.Error))
		.Replay().RefCount();
	
	mergedSubject.Subscribe();	
	
	rootSubject.OnNext(Types.Second);
	
	var result = mergedSubject.First();
	
	Console.WriteLine(String.Format("result - {0}", result));
