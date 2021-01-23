    public override int SaveChanges()
    {
        var entities = ChangeTracker.Entries<Entity1>()
                                    .Where(e => e.State == EntityState.Modified)
                                    .Select(e => e.Entity);
        foreach(var entity in entities)
        {
            // call your rutine.
        }
        return base.SaveChanges();
    }
