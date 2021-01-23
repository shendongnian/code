    var q = from c in db.Apr11log
            group c by c.LogDate into g
            orderby g.Key
            select new
            {
                LogDate = g.Key,
                MaxRow = g.OrderByDescending(c => c.Temp).Select(c => new { c.LogDate, c.Temp }).First(),
                MinRow = g.OrderBy(c => c.Temp).Select(c => new { c.LogDate, c.Temp }).First(),
                Rain = g.Max(c => c.Rain_today),
            };
