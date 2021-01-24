    IEnumerable<List<string>> sortedLists = _optoGrid.OrderByDescending(l => l[5]);
    foreach (List<string> l in sortedLists)
    {
        Console.WriteLine(string.Join(", ", l);
    }
