    var s = Console.ReadLine();
    foreach (var group in s.GroupBy(c => c).OrderByDescending(g => g.Count()))
    {
        Console.WriteLine(" {0}: {1}", group.Key, group.Count());
    }
