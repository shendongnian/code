      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
            
            var addMethod = typeof (ConfigurationRegistrar)
                .GetMethods()
                .Single(m =>
                        m.Name == "Add" &&
                        m.GetGenericArguments().Any(a => a.Name == "TEntityType"));
            var assemblies = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(a => a.GetName().Name != "EntityFramework");
            foreach (var assembly in assemblies)
            {
                var configTypes = assembly
                    .GetTypes()
                    .Where(t => t.BaseType != null &&
                                t.BaseType.IsGenericType &&
                                t.BaseType.GetGenericTypeDefinition() == typeof (EntityTypeConfiguration<>));
                foreach (var type in configTypes)
                {
                    var entityType = type.BaseType.GetGenericArguments().Single();
                    var entityConfig = assembly.CreateInstance(type.FullName);
                    addMethod.MakeGenericMethod(entityType)
                        .Invoke(modelBuilder.Configurations, new[] {entityConfig});
                }
            }
            base.OnModelCreating(modelBuilder);
        }
