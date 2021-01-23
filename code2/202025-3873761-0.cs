    var items = results.GroupBy(r => r.PrimaryKey).Select(grp => new ObjectA() 
                {
                    PrimaryKey = grp.Key,
                    Status = grp.Select(r => r.Status).First(),
                    Items = grp.Where(r => r.ItemName != null)
                           .Select(r => new Item() { Name = r.ItemName }).ToList()
                }.ToList();
