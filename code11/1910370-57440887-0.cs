	static async Task Main(string[] args)
	{
		Console.WriteLine("Start: " + Thread.CurrentThread.ManagedThreadId);
		var longTask = DoSomethingLong();
		Console.WriteLine("After long: " + Thread.CurrentThread.ManagedThreadId);
		for (int i = 0; i < 1000; i++)
			Console.Write(".");
		Console.WriteLine("Before main wait: " + Thread.CurrentThread.ManagedThreadId);
		await longTask;
		Console.WriteLine("After main wait: " + Thread.CurrentThread.ManagedThreadId);
	}
	static async Task DoSomethingLong()
	{
		Console.WriteLine("Before long wait: " + Thread.CurrentThread.ManagedThreadId);
		await Task.Delay(10);
		Console.WriteLine("After long wait: " + Thread.CurrentThread.ManagedThreadId);
		for (int i = 0; i < 1000; i++)
			Console.Write("<");
	}
