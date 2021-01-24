    modelBuilder.Entity<Contract>(builder =>
    {
    	var amounts = builder.Metadata.GetNavigations()
    		.Where(n => n.ClrType == typeof(Amount));
    	foreach (var amount in amounts)
    	{
    		var amountBuilder = builder.OwnsOne(amount.ClrType, amount.Name);
    		var amountProperties = amountBuilder.OwnedEntityType.GetProperties()
    			.Where(p => !p.IsKey());
    		foreach (var property in amountProperties)
    			amountBuilder.Property(property.Name).HasColumnName(amount.Name + property.Name);
    	}
    });
