    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
    	var allTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(i => i.GetTypes()).ToList();
    
    	foreach (var definition in swaggerDoc.Components.Schemas)
    	{
    		var type = allTypes.FirstOrDefault(x => x.Name == definition.Key);
    		if (type != null)
    		{
    			var properties = type.GetProperties();
    			foreach (var prop in properties.ToList())
    			{
    				var ignoreAttribute = prop.GetCustomAttribute(typeof(SwaggerIgnoreAttribute), false);
    
    				if (ignoreAttribute != null)
    				{
    					definition.Value.Properties.Remove(prop.Name);
    				}
    			}
    		}
    	}
    }
