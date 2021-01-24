	static void Main(string[] args)
	{
		var source = new Subject<Func<int>>();
	
		source
			.Synchronize()
			.Select(x => x())
			.Subscribe(result => Console.WriteLine($"Work of index {result} completed"));
	
		var noOfThreads = 3;
		for (var i = 0; i < noOfThreads; i++)
		{
			var i1 = i;
			var t = new Thread(() => source.OnNext(() => doWork(i1)));
			t.Start();
		}
	
		Console.ReadLine();
	}
	
	static int doWork(int index)
	{
		Console.WriteLine($"Start work {index}");
		Thread.Sleep(1000);
		Console.WriteLine($"Stop work {index}");
		return index;
	}
