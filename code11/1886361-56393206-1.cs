    // Make the method generic so we can use it on any context
    public List<string> GetProperties<TContext>(string dbSetName = "")
    	where TContext : DbContext // Make sure we have a Dbcontext
    {
    	var propertyNames = typeof(TContext)
            // Get all properties of context
    		.GetProperties() 
             // Filter out so we only have DbSet<> types
    		.Where(pi => pi.PropertyType.IsGenericType &&
    		    		 typeof(DbSet<>).IsAssignableFrom(pi.PropertyType.GetGenericTypeDefinition()))
            // If a DbSet name has been specified, filter it out
    		.Where(pi => string.IsNullOrEmpty(dbSetName) || pi.Name == dbSetName)
            // Get the generic type e.g. Foo
    		.Select(pi => pi.PropertyType.GetGenericArguments()[0])
            // Get the individual properties of the entity types
    		.Select(t => t.GetProperties())
            // Get all of the property names
    		.SelectMany(x => x.Select(pi => pi.Name)); 
    	
    	return propertyNames.ToList();
    }
