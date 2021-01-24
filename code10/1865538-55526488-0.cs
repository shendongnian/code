	var list = new MyReactiveList<int>();
	var item = new Subject<int>();
	list.Subscribe(values => Console.WriteLine($"[{string.Join(", ", values)}]"));
	list.Add(item);
	item.OnNext(1); // Will print out [1]
