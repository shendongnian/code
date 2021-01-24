    //Assigning BaseModel properties
    entity.CreatedBy = dbEnt.CreatedBy;
	entity.UpdatedBy = GetCurrentUser();
	entity.DateUpdated = DateTime.Now;
	entity.DateCreated = dbEnt.DateCreated;
    //Changing entity states
    _context.Entry(dbEnt).State = EntityState.Detached;
    _context.Entry(entity).State = EntityState.Modified;
    
    _context.SaveChanges();
