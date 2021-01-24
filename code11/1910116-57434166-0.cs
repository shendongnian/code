    if(dbContext.ChangeTracker.HasChanges())
    {
        dbContext.Entry(myRow).State = EntityState.Added;
        dbContext.SaveChanges();
    } 
