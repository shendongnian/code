    var typesToRegister = Assembly.GetAssembly(typeof(DbContext)).GetTypes()
    .Where(type => type.Namespace != null
           && type.Namespace.Equals(typeof(DBContext).Namespace))
          .Where(type => type.BaseType.IsGenericType
          && type.BaseType.GetGenericTypeDefinition() == 
             typeof(EntityTypeConfiguration<>));
    foreach (var type in typesToRegister)
    {
      dynamic configurationInstance = Activator.CreateInstance(type);
      modelBuilder.Configurations.Add(configurationInstance);
    }
