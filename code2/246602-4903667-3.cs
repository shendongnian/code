    string[] files = Directory.GetFiles(@"C:\", "*.*", SearchOption.AllDirectories);
    foreach (var extension in files.GroupBy(Path.GetExtension))
    {
        Console.WriteLine("{0}: {1} file(s)", extension.Key, extension.Count());
    }
    Console.ReadLine();
