    var lst = dbContext.JsonSchemas.GetAsNoTracking()
                    .GroupBy(a => new {a.Name, a.Version})
                    //.ToList()
                    .Select(g => g.OrderByDescending(t => t.AddedDate).FirstOrDefault())
                    .ToList();
