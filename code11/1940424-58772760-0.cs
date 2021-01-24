    var types = _dbContext.GetType().GetProperties();
    // Check if property is really a DbSet<TEntity>
    var filteredTypes = types.Where(x => x.PropertyType.IsGenericType 
                                      && x.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));
    foreach (var type in filteredTypes)
    {
         var dbSet = (IEnumerable<dynamic>) type.GetValue(_dbContext);    
         var entities = dbSet.ToList();
    }
