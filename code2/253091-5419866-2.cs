    protected void MapEntity(
        DbModelBuilder modelBuilder, Type entityType, string toTable, string discriminatorColumn = "Discriminator")
    {
        var method =
            GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(
                mi => mi.Name.StartsWith("MapEntity") && mi.IsGenericMethodDefinition).FirstOrDefault();
        var genericMethod = method.MakeGenericMethod(entityType);
        genericMethod.Invoke(this, new object[] { modelBuilder, toTable, discriminatorColumn });
    }
    protected void MapEntity<T>(
        DbModelBuilder modelBuilder, string toTable, string discriminatorColumn = "Discriminator")
        where T : class, IEntity
    {
        var config = modelBuilder.Entity<T>().Map(
            entity =>
                {
                    entity.MapInheritedProperties();
                    entity.Requires(discriminatorColumn).HasValue(typeof(T).FullName).IsOptional();
                });
        config.ToTable(toTable);
    }
