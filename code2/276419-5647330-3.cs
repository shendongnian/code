    var leafsDirs = Directory
        .EnumerateDirectories(Directory.GetCurrentDirectory(), "*", SearchOption.AllDirectories)
        .Where(sub => !Directory.EnumerateDirectories(sub).Any());
    
    leafsDirs.ToList().ForEach(Console.WriteLine);
