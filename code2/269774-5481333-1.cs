    // list is a List<object>
    var query = list.Cast<dynamic>()
                    .GroupBy(o => o.Security)
                    .ToDictionary(o => o.Key,
                        o => new SortedList<DateTime, double>(o.ToDictionary(x => (DateTime)x.Date, x => (double)x.zScore)));
    				
    foreach (var item in query)
    {
        Console.WriteLine("Security: " + item.Key);
        foreach (var kvp in item.Value)
            Console.WriteLine("Date: {0}, zScore: {1}", kvp.Key, kvp.Value);
    }
