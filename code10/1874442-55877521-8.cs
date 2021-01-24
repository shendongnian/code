	static async void Main(string[] args)
	{
		Program p = new Program();
		await p.MakeBreakfast();
		Console.WriteLine("Done!");
		Console.ReadLine();
	}
	public async Task MakeBreakfast()
	{
		await BoilWater();
		await StartToaster();
		await PutTeainWater();
		await PutBreadinToaster();
		await SpreadButter();
	}
