        IEnumerable<Schedule> schedules;
        DateTime someDateTime; // date time used for comparison
        IEnumerable<int> sourceIds; // required matching source Ids
    
        schedules.OrderBy(x=>x.StartTime)
        .Where(x => x.StartTime > someDateTime)
        .GroupBy(x=>x.Source.SourceId)
        .Where(x=>sourceIds.Contains(x.Key))
        .ToDictionary(x=>x.Key, x=>x.Take(3))
        .ToList()
