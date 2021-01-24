    foreach (var entityType in modelBuilder.Model.GetEntityTypes().Where(t => !t.IsOwned())
    {
        entityType.AsEntityType().Builder.Relational(ConfigurationSource.Convention)
            .ToTable(entityType.DisplayName());
    }
