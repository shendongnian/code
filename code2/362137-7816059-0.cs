    var list = new SortedList<DateTime, string>();
    
    list.Add(new DateTime(2000, 1, 1), "Hello World!");
    list.Add(new DateTime(2000, 1, 2), "Hello World!");
    list.Add(new DateTime(2001, 1, 1), "Hello World!");
    
    var desc = list.AsEnumerable().Reverse();
    
    foreach (var item in desc)
    {
        Console.WriteLine(item);
    }
