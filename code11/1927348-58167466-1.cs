     var result = list
       .GroupBy(item => RoundToMinutes(item.Date, 15))
       .Select(group => new MyObject() {
          ID    = group.First().ID,
          Value = group.First().Value,
          Time  = group.Key
        }) 
       .ToList(); // materialization if required
