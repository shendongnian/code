    IQueryable<Entity> Sample = dbContext.Entity.Where(condition);
    var data = from s in Sample
                  select new 
                  {
                      childlicense = s.ChildrenTable.Select(child => child.license)
                  }.ToList();
    var result = data.Select(p => new NewList { value  = string.Join(", ", p.childlicense) });
