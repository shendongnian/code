        /// <summary>
        /// This extension was built from code ripped out of the EF source.  I re-jigged it to find
        /// both constructors that are empty (like normal) and also those that have services injection
        /// in them and run the appropriate constructor for them and then run the config within them.
        ///
        /// This allows us to write EF configs that have injected services in them.
        /// </summary>
        public static ModelBuilder ApplyConfigurationsFromAssemblyWithServiceInjection(this ModelBuilder modelBuilder, Assembly assembly, params object[] services)
        {
            // get the method 'ApplyConfiguration()' so we can invoke it against instances when we find them
            var applyConfigurationMethod = typeof(ModelBuilder).GetMethods().Single(e => e.Name == "ApplyConfiguration" && e.ContainsGenericParameters &&
                                                                            e.GetParameters().SingleOrDefault()?.ParameterType.GetGenericTypeDefinition() ==
                                                                            typeof(IEntityTypeConfiguration<>));
            // test to find IEntityTypeConfiguration<> classes
            static bool IsEntityTypeConfiguration(Type i) => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>);
            // find all appropriate classes, then create an instance and invoke the configure method on them
            assembly.GetConstructableTypes()
                .ToList()
                .ForEach(t => t.GetInterfaces()
                    .Where(IsEntityTypeConfiguration)
                    .ToList()
                    .ForEach(i =>
                    {
                        {
                            var hasServiceConstructor = t.GetConstructor(services.Select(s => s.GetType()).ToArray()) != null;
                            var hasEmptyConstructor = t.GetConstructor(Type.EmptyTypes) != null;
                            if (hasServiceConstructor)
                            {
                                applyConfigurationMethod
                                    .MakeGenericMethod(i.GenericTypeArguments[0])
                                    .Invoke(modelBuilder, new[] { Activator.CreateInstance(t, services) });
                                Log.Information("Registering EF Config {type} with {count} injected services {services}", t.Name, services.Length, services);
                            }
                            else if (hasEmptyConstructor)
                            {
                                applyConfigurationMethod
                                    .MakeGenericMethod(i.GenericTypeArguments[0])
                                    .Invoke(modelBuilder, new[] { Activator.CreateInstance(t) });
                                Log.Information("Registering EF Config {type} without injected services", t.Name, services.Length);
                            }
                        }
                    })
                );
            
            return modelBuilder;
        }
        private static IEnumerable<TypeInfo> GetConstructableTypes(this Assembly assembly)
        {
            return assembly.GetLoadableDefinedTypes().Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition);
        }
        private static IEnumerable<TypeInfo> GetLoadableDefinedTypes(this Assembly assembly)
        {
            try
            {
                return assembly.DefinedTypes;
            }
            catch (ReflectionTypeLoadException ex)
            {
                return ex.Types.Where(t => t != null as Type).Select(IntrospectionExtensions.GetTypeInfo);
            }
        }
    }
Then in my OnModelCreating() I just call my extension...
modelBuilder.ApplyConfigurationsFromAssemblyWithServiceInjection(typeof(MyContext).Assembly, myService, myOtherService);
This implementation is not ideal as all your configs must have either a parameter-less constructor or a constructor with a fixed list of services (ie can't have ClassA(serviceA), ClassB(ServiceB); you can only have ClassA(serviceA, serviceB), ClassB(serviceA, serviceB) but that is not a problem for my use case, as this is exactly what I need at the moment.
If I needed a more flexible path I was going to go down the path of making the modelbuilder container aware and then doing the service resolution inside using the DI container, but I don't need that at the moment.
