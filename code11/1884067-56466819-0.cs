    var dbEnt = _context.Set<TEntity>().Where(c => c.Id == entity.Id).First();
    
    entity.CreatedBy = dbEnt.CreatedBy;
    entity.UpdatedBy = GetCurrentUser();
    entity.DateUpdated = DateTime.Now;
    entity.DateCreated = dbEnt.DateCreated;
    
    _context.Set<TEntity>().AddOrUpdate(entity);
    
    _context.SaveChanges();
