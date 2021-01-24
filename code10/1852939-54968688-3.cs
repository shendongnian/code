    public static class ModelExtensions
    {
    	/// <summary>
    	/// Extension method used to get from the entity all navigation properties by multiplicity
    	/// </summary>
    	/// <typeparam name="T">Entity from where the navigation properties are taken</typeparam>
    	/// <param name="model">Context Model</param>
    	/// <param name="multiplicity">Type of multiplicity to use</param>
    	/// <returns>List of PropertyInfo of Navigation Properties</returns>
    	public static IEnumerable<PropertyInfo> GetNavigationProperties<T>(this IModel model, RelationshipMultiplicity multiplicity)
    	{
    		var navigations = model.GetEntityTypes().FirstOrDefault(m => m.ClrType == typeof(T))?.GetNavigations();
    		var properties = new List<PropertyInfo>();
    
    		switch (multiplicity)
    		{
    			case RelationshipMultiplicity.Many:
    				properties.AddRange(
    					navigations?.Where(nav => nav.IsCollection()).Select(nav => nav.PropertyInfo)
    				);
    				break;
    
    			case RelationshipMultiplicity.One:
    				properties.AddRange(
    					navigations?.Where(nav => !nav.IsCollection() && nav.ForeignKey.IsRequired).Select(nav => nav.PropertyInfo)
    				);
    				break;
    			case RelationshipMultiplicity.ZeroOrOne:
    				properties.AddRange(
    					navigations?.Where(nav => !nav.IsCollection()).Select(nav => nav.PropertyInfo)
    				);
    				break;
    		}
    
    		return properties;
    	}
    }
