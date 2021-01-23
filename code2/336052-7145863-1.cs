    IEnumerable<IGrouping<int, MyItem>> grouped = items
        .GroupBy(t => t.PartNumber)
        .OrderBy(t => t.Key);
    foreach(var item in grouped)
    {
        Console.WriteLine("Number of Occurances:" + item.Key);
        Console.WriteLine("Name: " + item.ElementAt(0).Name);
        Console.WriteLine("Description: " + item.ElementAt(0).Description);
        Console.WriteLine("\n --------------------------------- \n");
    }
