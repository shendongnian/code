	public string Method1()
	{
		Console.WriteLine("Method1 Start");
		Thread.Sleep(TimeSpan.FromSeconds(2.0));
		Console.WriteLine("Method1 End");
		return null; //"1";
	}
	
	
	public string Method2()
	{
		Console.WriteLine("Method2 Start");
		Thread.Sleep(TimeSpan.FromSeconds(3.0));
		Console.WriteLine("Method2 End");
		return "2";
	}
	
	public string Method3(string x)
	{
		Console.WriteLine("Method3 Start");
		Thread.Sleep(TimeSpan.FromSeconds(2.0));
		Console.WriteLine("Method3 End");
		return $"3-{x}";
	}
