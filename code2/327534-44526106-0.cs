	<#
	var entitiesWithDateTime = typeMapper.GetItemsToGenerate<EntityType>(itemCollection)
									.Where(e => e.Properties.Any(p => typeMapper.GetTypeName(p.TypeUsage) == "System.DateTime"));
						
	if(entitiesWithDateTime.Count() > 0)
	{
	#>
		private void ObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
		{
	<#
		var count = 0;
		foreach (var entityType in entitiesWithDateTime)
		{
	#>
			<#=count != 0 ? "else " : String.Empty#>if(e.Entity is <#=entityType.Name#>)
			{
				var entity = e.Entity as <#=entityType.Name#>;
	<#
				foreach(var property in entityType.Properties.Where(p => typeMapper.GetTypeName(p.TypeUsage) == "System.DateTime"))
				{
	#>
				entity.<#=property.Name#> = DateTime.SpecifyKind(entity.<#=property.Name#>, DateTimeKind.Utc);
	<#
				}
	#>
			}
	<#
			count++;
		}
	#>
		}
	<#
	}
	#>
