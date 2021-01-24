    var sortedList = new SortedList<string, MyObject>();
    sortedList.Add("ZZZ", new MyObject { Id = 1, Name = "ZZZ" });
    sortedList.Add("NNN", new MyObject { Id = 2, Name = "NNN" });
    sortedList.Add("PPP", new MyObject { Id = 3, Name = "PPP" });
    sortedList.Add("AAA", new MyObject { Id = 4, Name = "AAA" });
    // Below would fail, because the key needs to be unique...
    // sortedList.Add("AAA", new MyObject { Id = 5, Name = "AAA" });
    foreach (var entry in sortedList)
    {
        Console.WriteLine($"{entry.Value.Name} -> {entry.Value.Id}");
    }
