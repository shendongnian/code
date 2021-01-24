    public static void ReadNumbers()
    {
        string[] lines = File.ReadAllLines("text.TXT");
        var groups = lines
            .Where(line => line.StartsWith("Time"))
			.Select(line => Int32.Parse(new String(line.Where(Char.IsDigit).ToArray())))
			.GroupBy(number => number);
        for(int i = 1; i <= 3; i ++)
        {
            var count = groups.FirstOrDefault(group => group.Key == i)?.Count() ?? 0;
			Console.WriteLine($"Total Members Registered for Slot {i}: {count}");
        }
    }
