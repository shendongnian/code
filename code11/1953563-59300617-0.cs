    foreach (var group in _timeEntries.GroupBy(x => x.Value.Category))
    {
        Console.WriteLine(group.Key);
        foreach (var entry in group)
        {
            var timespan = entry.Value.EndTime - entry.Value.StartTime;
            Console.WriteLine($"  {timespan.ToString(@"hh\:mm\:ss")} {entry.Value.Task}");
        }
    }
