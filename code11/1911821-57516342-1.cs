c#
var ownedTypes = modelBuilder.Model.GetEntityTypes().Where(e => e.IsOwned());
    foreach (var type in ownedTypes)
    {
        foreach (var prop in type.GetProperties())
        {
            var entityName = type.DefiningEntityType.Name;
            var ownedType = type.ClrType;
            var navigationName = type.DefiningNavigationName;
            var propertyName = prop.Name;
            var newColumnName = $"{navigationName}{propertyName}";
            var primaryKeyName = modelBuilder.Model.GetEntityTypes().SingleOrDefault(e => e.Name == entityName)?.GetProperties().SingleOrDefault(p => p.IsPrimaryKey())?.Name;
            if (string.IsNullOrWhiteSpace(primaryKeyName) || propertyName != primaryKeyName)
            {
                modelBuilder.Entity(entityName).OwnsOne(ownedType, navigationName, sa =>
                {
                    sa.Property(propertyName).HasColumnName(newColumnName);
                });
            }
        }
    }
I would still be glad if you could point me to a better, cleaner solution, should there be one. Or maybe there are some issues here in my code.
