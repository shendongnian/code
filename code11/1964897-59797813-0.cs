    var list = new List<Activity>
    {
        new Activity { Type = "IN", Date = DateTime.Now },
        new Activity { Type = "OUT", Date = DateTime.Now.AddSeconds(15) },
        new Activity { Type = "IN", Date = DateTime.Now.AddSeconds(23) },
        new Activity { Type = "OUT", Date = DateTime.Now.AddSeconds(27) }
    };
            
    var result = new List<string>();
    for (var i = 0; i < list.Count - 1; i++)
    {
        var current = list[i];
        var next = list[i+1];
        if (current.Type == "OUT" || current.Type == next.Type)
        {
            continue;
        }
        var duration = next.Date - current.Date;
        result.Add($"{current.Date:yyyy-MM-dd} | {duration.Minutes:00}:{duration.Seconds:00}");
    }
