	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		// model mappings
		base.OnModelCreating(modelBuilder);
		// table mapping
		var config = modelBuilder.Configurations
			.GetPrivateFieldValue("_modelConfiguration")
			.GetPrivateFieldValue("ActiveEntityConfigurations");
		var mapping = new Hashtable();
		foreach (var c in (IEnumerable)config)
		{
			var type = (Type)c.GetPrivateFieldValue("ClrType");
			var tableName = (string)c.GetPrivateFieldValue("EntitySetName");
			mapping[type] = tableName;
		}
		// store mapping whereever needed
	}
