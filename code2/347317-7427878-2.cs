    var data = MemoryCache.Default[KeyTwitterData];
    if (data == null)
    {
        data = SomeExpensiveOperationToFetchData();
        MemoryCache.Default.Add(KeyTwitterData, data, DateTime.Now.AddMinutes(5));
    }
    // use the data variable here
