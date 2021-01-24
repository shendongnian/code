    public static void ReadNumbers()
    {
        string[] lines = File.ReadAllLines("text.TXT");
        var groups = lines
            .Where(line => line.StartsWith("Time"))
			.Select(line => Int32.Parse(new string(line.Where(Char.IsDigit).ToArray())))
			.GroupBy(number => number);
        foreach(var group in groups)
			Console.WriteLine($"{group.Key} appeared: {group.Count()} times");
    }
