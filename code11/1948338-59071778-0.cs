    public static void ReadNumbers()
    {
        string[] lines = File.ReadAllLines("text.TXT");
                
        var groups = lines.Where(line => line.StartsWith("Time"))
            .Select(line => line.Where(Char.IsDigit).ToArray())
            .GroupBy(charArray => charArray[0]);
    
        foreach (var group in groups)
            Console.WriteLine($"{group.Key} appeared: {group.Count()} times");
    }
