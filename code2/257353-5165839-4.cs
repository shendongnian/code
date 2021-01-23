    foreach (var line in File.ReadLines(@"c:\temp\input.txt")
                             .Where(s => s.StartsWith("4TOT")))
    {
        string value = string.IsNullOrEmpty(line) ? string.Empty : line.Split('|')[2];
        Console.WriteLine(value);
    }
