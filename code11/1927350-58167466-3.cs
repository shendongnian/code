     var result = list
       .GroupBy(item => RoundToMinutes(item.Date, 15))
       .Select(group => new {
          at   = group.Key,
          best = group.Aggregate((s, a) => 
            Math.Abs((s.Time - group.Key).TotalSeconds) < 
            Math.Abs((a.Time - group.Key).TotalSeconds) 
             ? s 
             : a) 
        })
       .Select(group => new MyObject() {
          ID    = group.at,
          Value = group.best.Value,
          Time  = group.best.Key
        }) 
       .ToList(); // materialization if required
