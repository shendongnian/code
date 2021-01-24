    var result = (from item in _dbContext.JsonSchemas.ToList()
                     group item by new { item.Name, item.Version } into r
                     select new
                     {
                         Id = r.Select(q => q.Id).First(),
                         Name = r.Key.Name,
                         Version = r.Key.Version,
                         AddedDate = r.Max(q => q.AddedDate)
                     }).ToList();
      
