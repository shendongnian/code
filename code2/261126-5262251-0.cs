    Console.WriteLine("Starting...");
    IEnumerable<string> files = Directory.EnumerateFiles("C:\\temp\\test\\2010", @"2010*.xml", SearchOption.TopDirectoryOnly).ToList();
    foreach (string file in files)
    {
        Console.WriteLine("Found[{0}]", file);
    }
    Console.ReadLine();
