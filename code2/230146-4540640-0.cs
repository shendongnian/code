	static void Main()
	{
		var cpuLoadSequence = Observable.GenerateWithTime(
			0, // initial value
			i => true, // continue forever
			i => i + 1, // increment value
			i => i, // result = value
			i => TimeSpan.FromSeconds(3)); // delay 3 seconds
		using (cpuLoadSequence.Subscribe(x => Console.WriteLine("load: {0}%", x)))
		{
			Console.WriteLine("Press ENTER to stop.");
			Console.ReadLine();
		}
	}
