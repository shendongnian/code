    public override int SaveChanges()
    {
        var newEntities = ChangeTracker.Entries()
                            .Where(entry => entry.State == EntityState.Added)
                            .Select(entry => entry.Entity).ToList();
    
        var count = base.SaveChanges();
    
        // do something with newEntities
     
        return count;
    }
