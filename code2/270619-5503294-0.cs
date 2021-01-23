    public override int SaveChanges()
    {
        foreach(var entry in ChangeTracker.Entries<EditableBase>())
        {
            var entity = entry.Entity;
            if (entry.State == EntityState.Added)
            {
                entity.CreatedOn = ...;
                entity.CreatedBy = ...;
            }
            else if (entry.State == EntityState.Modified)
            {
                entity.ModifiedOn = ...;
                entity.ModifiedBy = ...;
            }
        }
    
        return base.SaveChanges();
    }
