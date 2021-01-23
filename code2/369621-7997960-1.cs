    IEnumerable<Bar> bars = ...
    
    var lowestPriceBars = bars.GroupBy(bar => new { bar.BeginTime, bar.EndTime, bar.Date } )
                              .Select(g => g.OrderBy(bar => bar.Price).First())
                              .ToArray();
         
