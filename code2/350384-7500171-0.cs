    Type tCmpxTypeConfig = typeof (EntityTypeConfiguration<>);
    tCmpxTypeConfig = tCmpxTypeConfig.MakeGenericType(t);
    modelBuilder.Configurations.GetType()
        .GetMethod("Add", new Type[] { tCmpxTypeConfig })
        .MakeGenericMethod(t)
        .Invoke(modelBuilder.Configurations, 
            new object[] { Activator.CreateInstance(t) });
