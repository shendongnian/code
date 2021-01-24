    var prop1 = new Dictionary<DateTime, List<string>>();
    var prop2 = new Dictionary<DateTime, List<string>>();
    var prop3 = new Dictionary<DateTime, List<int>>();
    foreach (var grouped in list.GroupBy(l => l.TimeStamp))
    {
        prop1.Add(grouped.Key, grouped.Select(i => i.Property_1).ToList());
        prop2.Add(grouped.Key, grouped.Select(i => i.Property_2).ToList());
        prop3.Add(grouped.Key, grouped.Select(i => i.Property_3).ToList());
    }
