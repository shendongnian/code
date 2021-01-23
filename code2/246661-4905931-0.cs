    var groups = assembly.GetTypes().GroupBy(t => t.Namespace);
    foreach (var group in groups)
    {
        Console.WriteLine("Namespace: {0}", group.Key);
        foreach (var type in group)
        {
            Console.WriteLine("  {0}", t.Name);
        }
    }
