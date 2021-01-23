    var seen = new HashSet<string>();
    foreach (var item in items)
    {
        if (!seen.Add(item.name))
        {
            Console.WriteLine(item.id);
        }
    }
