		var choices = new Dictionary<ConsoleKey, bool?>()
		{
			{ ConsoleKey.D1, true },
			{ ConsoleKey.D2, false }
		};
		var ascending = (bool?)null;
		while (ascending == null)
		{
			Console.WriteLine("Please choose between ascending and descending order.");
			Console.WriteLine("Press 1 for ascending");
			Console.WriteLine("Press 2 for descending");
			var choice = Console.ReadKey(true);
			ascending = choices.ContainsKey(choice.Key) ? choices[choice.Key] : null;
		}
		var lines = File.ReadAllLines("c:/data.txt");
		lines = ascending.Value
			? lines.OrderBy(x => x).ToArray()
			: lines.OrderByDescending(x => x).ToArray();
		foreach (var line in lines)
		{
			Console.WriteLine(line);
		}
		Console.WriteLine("Press any key to continue...");
		Console.ReadKey(true);
