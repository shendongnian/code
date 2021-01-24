    List<ActivityForecast> activityForecast = ...
    
    var result = activityForecast
      .GroupBy(forecast => new {
         forecast.ArDate,
         forecast.Category,
       })
      .Select(group => new ActivityForecast() {
         // These values are taken from Key:
         ArDate   = group.Key.ArDate,
         Category = group.Key.Category,
         // These values should be aggregated over group:
         // Providing that Type is string  
         Type     = string.Join(",", group.Select(item => item.Type).Distinct()),
         //TODO: put correct aggregate function here (Sum? Max?)
         Arr      = group.Sum(item => item.Arr),
         Dep      = group.Sum(item => item.Dep),
         Slp      = group.Sum(item => item.Slp),
       });
