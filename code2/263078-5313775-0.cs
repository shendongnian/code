    var items = new[] { new { Group = 1, TimePoint = 0, Value = 1} ... };
    var answer = items.GroupBy(x => new { TimePoint = x.TimePoint, Group = x.Group })
                      .Select(x => new { 
                                         Group = x.Key.Group,
                                         TimePoint = x.Key.TimePoint,
                                         AverageValue = x.Average(y => y.Value),
                                       }
                      );
