    var result = activityForecast.GroupBy(c => new
                {
                    c.ArrivalDate,
                    c.Category
                })
                     .Select(o =>
                     {
                         var first = o.First();
                         return new ActivityForecast
                         {
                             ArDate = first .ArDate,
                             Category = first .Category,
                             ArrvlRms = o.Sum(g => g.Arr),
                             Type = string.Join(",", o),
                             Dep = o.Sum(g => g.Dep),
                             Slp = o.Sum(g => g.Slp)
                         };
                     });
