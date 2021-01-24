    public static void Main()
	{
		var rand = new Random();
		
		var elements = Enumerable.Range(0, 8).Select(_ => rand.Next(1, 49));
		
		var duplicates = elements.GroupBy(x => x).Where(x => x.Count() > 1).ToArray();
		
		if (duplicates.Any())
		{
			Console.WriteLine("duplicates found");	
		}
		else
		{
			Console.WriteLine("no duplicates");	
		}
	}
