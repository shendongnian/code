    var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.GetProperties().Any(y => y.PropertyType == typeof(Service)))
                .ToList();
    (instance.GetType().GetProperties().Where(y => y.PropertyType == typeof(DbSet<Service>))
    .First().GetValue(instance) as DbSet<Service>).Add(newItem);
