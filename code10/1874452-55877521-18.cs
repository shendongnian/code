	static async Task Main(string[] args)
	{
		Program p = new Program();
		await p.MakeBreakfast();
		Console.WriteLine("Done!");
		Console.ReadLine();
	}
	public async Task MakeBreakfast()
	{
		var tasks = new[]
		{
			BoilWater(),
			StartToaster(),
			PutTeainWater(),
			PutBreadinToaster(),
			SpreadButter(),
		};
		await Task.WhenAll(tasks);
	}
