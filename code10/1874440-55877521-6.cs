	static void Main(string[] args)
	{
		Program p = new Program();
		p.MakeBreakfast();
		Console.WriteLine("Done!");
		Console.ReadLine();
	}
	public async Task MakeBreakfast()
	{
		Console.WriteLine("Starting MakeBreakfast");
		Thread.Sleep(1000);
		Console.WriteLine("Calling await BoilWater()");
		await BoilWater();
		Console.WriteLine("Done await BoilWater()");
		StartToaster();
		PutTeainWater();
		PutBreadinToaster();
		SpreadButter();
	}
