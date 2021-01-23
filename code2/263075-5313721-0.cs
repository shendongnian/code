    var query = from item in inputTable
                group item by new { Group = item.Group, TimePoint = item.TimePoint } into grouped
                select new
                {
                    Group = grouped.Key.Group,
                    TimePoint = grouped.Key.TimePoint,
                    AverageValue = grouped.Average(x => x.Value)
                } ;
