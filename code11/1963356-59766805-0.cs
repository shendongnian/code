    var enumerable = from type in assemblies.Where((Assembly assembly) => !assembly.IsDynamic).SelectMany(GetExportedTypes)
    		where !type.IsAbstract && !type.IsGenericTypeDefinition
    		select new
    		{
    			Lifetime = type.GetCustomAttribute<ControllerAttribute>()?.Lifetime,
    			ServiceType = type,
    			ImplementationType = type.GetCustomAttribute<ControllerAttribute>()?.ControllerType
    		} into t
    		where t.Lifetime.HasValue
    		select t;
    	foreach (var item in enumerable)
    	{
    		if (item.ImplementationType == null)
    		{
    			serviceCollection.Add(item.ServiceType, item.Lifetime.Value);
    		}
    		else
    		{
    			serviceCollection.Add(item.ImplementationType, item.ServiceType, item.Lifetime.Value);
    		}
