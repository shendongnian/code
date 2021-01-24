    var deletedEntities = ChangeTracker.Entries().Where(e => e.State == 
                        EntityState.Deleted && e.Entity is ISoftDeletable).ToList();
    deletedEntities.ForEach(e =>
        {
            try
            {
                e.Property("DeletedAt").CurrentValue = DateTime.Now;
                e.State = EntityState.Modified;
            }
            catch (System.Exception)
            {
            }
        });
