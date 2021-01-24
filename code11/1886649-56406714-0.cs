	async void Main()
	{
		await TotalTimer();
		Console.WriteLine("Done.");
	}
	
	async Task TotalTimer()
	{
		while (true)
		{
			await Task.Delay(1000);
	
			if (true)
			{
				break;
			}
		}
	}
