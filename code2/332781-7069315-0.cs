    var query = from c in context.Table
                select new
                {
                  Entity = c,
                  IntOrder = context.Table
                               .Take(1)
                               .Select(x => c.KeyAsString)
                               .Cast<int>()
                               .FirstOrDefault()
                };
    var query2 = from c in query
                 where key == c.IntOrder
                 orderby c.IntOrder
                 select c.Entity
