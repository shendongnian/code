    var dbEnt = _context.Set<TEntity>().Where(c => c.Id == entity.Id).First();
    dbEnt.Name = entity.Name;
    ...
    ...
    ...
    dbEnt.UpdatedBy = GetCurrentUser();
    dbEnt.DateUpdated = DateTime.Now;
    _context.Entry(dbEnt).State = EntityState.Modified;
    _context.SaveChanges();
