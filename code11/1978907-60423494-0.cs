    var lst = dbContext.JsonSchemas.GetAsNoTracking()
                .GroupBy(a => new {a.Name, a.Version}).Select(a => new
                {
                    Name = a.Key.Name,
                    Version = a.Key.Version,
                    RecentAddedDate = a.Max(f => f.AddedDate)
                }).ToList();
