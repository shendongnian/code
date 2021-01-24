    class YourAssemblyEndpointDefinition :
    	DefaultEndpointDefinition
    {
    	public HubEndpointDefinition()
    		: base(true)
    	{
    	}
    
    	public override string GetEndpointName(IEndpointNameFormatter formatter)
    	{
    		return formatter.TemporaryEndpoint($"{typeof(YourType).Assembly.GetName()}");
    	}
    }
