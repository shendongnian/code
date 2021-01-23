    var currentContext = new AuthContext();
    var dbSets = typeof(AuthContext).GetProperties(BindingFlags.Public | 
                                                   BindingFlags.Instance);
    dbSets.Where(pi => pi.PropertyType.IsGenericTypeDefinition &&
                       pi.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
          .ToList()
          .ForEach(pi => ExtensionClass.Clear((dynamic)pi.GetValue(currentContext, 
                                                                   null)));
