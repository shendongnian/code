	var a = source.Where(i => i % 3 == 0);
	var b = source.Where(i => i % 3 == 1);
	var c = source.Where(i => i % 3 == 2);
	var l = new List<IObservable<int>>() { a, b, c };
	l.ToObservable()
		.Merge(2)
		.Subscribe(Console.WriteLine); //Outputs 0 1 3 4 6 7 9 2 5 8
