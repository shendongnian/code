    public void SaveChanges()
    {
    	foreach (var entry in Context.ChangeTracker.Entries<ICreatedAt>().Where(x => x.State == EntityState.Added && x.Entity.CreatedAt == default(DateTime)))
    			entry.Entity.CreatedAt = DateTime.Now;
    
    	foreach (var entry in Context.ChangeTracker.Entries<ICreatedBy>().Where(x => x.State == EntityState.Added && x.Entity.CreatedBy == null))
    		entry.Entity.CreatedBy = ContextManager.CurrentUser;
    
    	foreach (var entry in Context.ChangeTracker.Entries<IModifiedAt>().Where(x => x.State == EntityState.Modified))
    		entry.Entity.ModifiedAt = DateTime.Now;
    
    	foreach (var entry in Context.ChangeTracker.Entries<IModifiedBy>().Where(x => x.State == EntityState.Modified))
    		entry.Entity.ModifiedBy = ContextManager.CurrentUser;
    
    	Context.SaveChanges();
    }
