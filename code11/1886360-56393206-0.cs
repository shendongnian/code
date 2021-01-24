    //Make the method generic so we can use it on any context
    public List<string> GetProperties<TContext>()
    	where TContext : DbContext // Make sure we have a Dbcontext
    {
    	var propertyNames = typeof(TContext)
    		.GetProperties() //Get all properties of context
             //Filter out so we only have DbSet<> types
    		.Where(pi => pi.PropertyType.IsGenericType &&
    		    		 typeof(DbSet<>).IsAssignableFrom(pi.PropertyType.GetGenericTypeDefinition()))
            // Get the generic type e.g. Foo
    		.Select(pi => pi.PropertyType.GetGenericArguments()[0])
            // Get the individual properties of the entity types
    		.Select(t => t.GetProperties())
            //Get all of the property names
    		.SelectMany(x => x.Select(pi => pi.Name)); 
    	
    	return propertyNames.ToList();
    }
