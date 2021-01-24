    public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            foreach (var entityEntry in ChangeTracker.Entries().Where(entry => entry.State == EntityState.Deleted))
            {
                var oldEntity = entityEntry.Entity;
                // my callback
            }
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
