	var sc = new SomeClass();
	sc.Actions.Subscribe(x => Console.WriteLine($"1:{x}"));
	sc.AddActionCreator(Observable.Return("Hello"));
	sc.Actions.Subscribe(x => Console.WriteLine($"2:{x}"));
	sc.AddActionCreator(Observable.Range(0, 3).Select(x => $"{x}"));
	sc.Actions.Subscribe(x => Console.WriteLine($"3:{x}"));
	sc.AddActionCreator(Observable.Return("World"));
