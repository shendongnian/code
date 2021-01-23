    IEnumerable<MyClass> table = ...
    var query = from item in table
                group item by new { item.Group, item.TimePoint } into g
                select new
                {
                    g.Key.Group,
                    g.Key.TimePoint,
                    AverageValue = g.Average(i => i.Value)
                };
