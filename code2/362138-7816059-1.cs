    var list = new SortedList<DateTime, string>();
    
    list.Add(new DateTime(2000, 1, 2), "Third");
    list.Add(new DateTime(2001, 1, 1), "Second");
    list.Add(new DateTime(2010, 1, 1), "FIRST!");
    list.Add(new DateTime(2000, 1, 1), "Last...");
    var desc = list.Reverse();
    
    foreach (var item in desc)
    {
        Console.WriteLine(item);
    }
