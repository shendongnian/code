    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
    {
    	foreach (var navigation in entityType.GetNavigations().ToList())
    	{
    		if (navigation.ClrType == typeof(Measurement))
    		{
    			var entityTypeBuilder = modelBuilder.Entity(entityType.ClrType);
    			entityTypeBuilder
    				.Property<Measurement>(navigation.Name)
    				.HasConversion(measurementConverter);
    		}
    	}
    }
 
