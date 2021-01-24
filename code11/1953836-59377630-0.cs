    Func<IServiceProvider, object> factoryMethod = sp =>
    {
    	if (condition1 && condition2)
    	{
    		return ActivatorUtilities.CreateInstance<ServiceOne>(sp);
    	}
    	else
    	{
    		return ActivatorUtilities.CreateInstance<ServiceTwo>(sp);
    	}
    };
    
    services.Replace(ServiceDescriptor.Describe(typeof(IService), factoryMethod, ServiceLifetime.Transient));
