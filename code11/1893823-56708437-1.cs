    var events_list = new YearMonthDayTree<EventObj>();
    events_list.Add(2019, 6, 21, new EventObj());
    events_list.Add(2019, 6, 22, new EventObj());
    events_list.Add(2019, 6, 22, new EventObj());
    foreach (var entry in events_list.Flatten())
    {
        Console.WriteLine($"{entry.Year}.{entry.Month}.{entry.Day} {entry.Item}");
    }
