        var result = datas.Select(p => new
        {
            week = EntityFunctions.DiffDays(EntityFunctions.CreateDateTime(p.Date.Year, 1, 1, 0, 0, 0), p.Date.Value).Value / 7,
            Date= p.Date,
            Revenue= p.Revenue
        }).GroupBy(p => p.week)
        .Select(p => new
        {
            week=p.Key,
            Date=string.Format("{0:M/d/yyyy}",p.Min(q=>q.Date))+"-"+string.Format("{0:M/d/yyyy}",p.Max(q=>q.Date))
            Revenue=p.Average(q=>q.Revenue)
        }).ToList();
