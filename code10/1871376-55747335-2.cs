	[STAThread]
	private static void Main(string[] args)
	{
		AsyncPump.Run(async () =>
		{
			await Task.Delay(2000);
		});
		
		// We're still on the Main thread!
	}
