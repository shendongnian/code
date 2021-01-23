    var list = (from c in db.Apr11log
            group c by c.LogDate into g
            orderby g.Key
            select new
            {
                LogDate = g.Key,
                Temp = g.Temp,
                Rain = g.Max(c => c.Rain_today),
            })
            .ToList();
    var maxRow = list.OrderByDescending(arg => arg.Temp).First();
    var minRow = list.OrderBy(arg => arg.Temp).First();
