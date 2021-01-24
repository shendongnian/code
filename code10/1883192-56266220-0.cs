	Action<int> action = i =>
	{
		Console.WriteLine($"Starting action {i}");
		Thread.Sleep(5000);
		Console.WriteLine($"Ending action {i}");
	};
	var option = new ParallelOptions()
	{
		MaxDegreeOfParallelism = 2
	};
	Parallel.For(0, 10, option, action);
