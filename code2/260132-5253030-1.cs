	var mergedSubject = Observable
						.Merge(firstSubject, secondSubject, thirdSubject, forthSubject)
						.Timeout(TimeSpan.FromSeconds(2), Observable.Return(Types.Error))    
						.Replay(1);
	
	mergedSubject.Connect();
	
	rootSubject.OnNext(Types.First);
	rootSubject.OnNext(Types.Second);
	var result = mergedSubject.First();	
	rootSubject.OnNext(Types.Third);
	rootSubject.OnNext(Types.Fourth);
	
	Console.WriteLine(String.Format("result - {0}", result));
