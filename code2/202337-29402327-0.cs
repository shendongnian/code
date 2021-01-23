    public override int SaveChanges()
        {
            var objectStateEntries = ChangeTracker.Entries()
                .Where(e => e.Entity is TrackedEntityBase && e.State == EntityState.Modified || e.State == EntityState.Added).ToList();
            var currentTime = DateTime.UtcNow;
            foreach (var entry in objectStateEntries)
            {
                var entityBase = entry.Entity as TrackedEntityBase;
                if (entityBase == null) continue;
                if (entry.State == EntityState.Added)
                {
                    entityBase.CreatedDate = currentTime;
                }
                entityBase.LastModifiedDate = currentTime;
            }
            return base.SaveChanges();
        }
