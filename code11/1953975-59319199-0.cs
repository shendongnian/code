    foreach (var entry in db.ChangeTracker.Entries().Where(entry => entry.State == EntityState.Added || entry.State == EntityState.Modified))
    {
        // Gets all properties from the changed entity by reflection.
        foreach(var entityProperty in entry.Entity.GetType().GetProperties())
        {
            var propertyName = entityProperty.Name;
            var currentValue = entry.Property(propertyName).CurrentValue;
            var originalValue = entry.Property(propertyName).OriginalValue;
        }
    }
