		var choices = new Dictionary<ConsoleKey, Func<string[], string[]>>()
		{
			{ ConsoleKey.D1, xs => xs.OrderBy(x => x).ToArray() },
			{ ConsoleKey.D2, xs => xs.OrderByDescending(x => x).ToArray() }
		};
		var ascending = (Func<string[], string[]>)null;
		while (ascending == null)
		{
			Console.WriteLine("Please choose between ascending and descending order.");
			Console.WriteLine("Press 1 for ascending");
			Console.WriteLine("Press 2 for descending");
			var choice = Console.ReadKey(true);
			ascending = choices.ContainsKey(choice.Key) ? choices[choice.Key] : null;
		}
		var lines = ascending(File.ReadAllLines("c:/data.txt"));
		foreach (var line in lines)
		{
			Console.WriteLine(line);
		}
		Console.WriteLine("Press any key to continue...");
		Console.ReadKey(true);
