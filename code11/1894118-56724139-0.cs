	void Main()
	{
		Console.WriteLine($"Main 0 - {Thread.CurrentThread.ManagedThreadId}");
		DoJob();
		Console.WriteLine($"Main 1 - {Thread.CurrentThread.ManagedThreadId}");
	}
	
	public static async Task DoJob()
	{
		Console.WriteLine($"DoJob 0 - {Thread.CurrentThread.ManagedThreadId}");
		Thread.Sleep(2000);
		Console.WriteLine($"DoJob 1 - {Thread.CurrentThread.ManagedThreadId}");
	}
