    var entityTypes = modelBuilder.Model.GetEntityTypes()
    	.ToList();
    
    foreach (var entityType in entityTypes)
    {
    	var properties = entityType
    		.GetProperties()
    		.ToList();
    
    	// (1)
    	var entityTypeBuilder = new EntityTypeBuilder(entityType.AsEntityType().Builder);
    	
    	foreach (var property in properties)
    	{
    		if (property.PropertyInfo == null)
    		{
    			continue;
    		}
    
    		if (property.PropertyInfo.PropertyType.IsBoolean())
    		{
    			entityTypeBuilder // (2)
    			.Property(property.Name)
    			.HasConversion(new BoolToZeroOneConverter<short>())
    			.HasColumnType("tinyint(1)");
    		}
    	}
    }
 
