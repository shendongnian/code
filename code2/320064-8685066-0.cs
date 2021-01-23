    ChannelFactory<T> GetCachedFactory<T>()
    {
    	var endPointName = EndPointNameLookUp<T>();
    	return new ChannelFactory<T>(endPointName);
    }
    
    // Determines the name of the endpoint the factory will create by finding the endpoint in the config file which is the same as the type of the service the factory is to create
    string EndPointNameLookUp<T>()
    {
    	var contractName = LookUpContractName<T>();
    	foreach (ChannelEndpointElement serviceElement in ConfigFileEndPoints)
    	{
    		if (serviceElement.Contract == contractName) return serviceElement.Name;
    	}
    	return string.Empty;
    }
    
    // Retrieves the list of endpoints in the config file
    ChannelEndpointElementCollection ConfigFileEndPoints
    {
    	get
    	{
    		return ServiceModelSectionGroup.GetSectionGroup(
    			ConfigurationManager.OpenExeConfiguration(
    				ConfigurationUserLevel.None)).Client.Endpoints;
    	}
    }
    
    // Retrieves the ConfigurationName of the service being created by the factory
    string LookUpContractName<T>()
    {
    	var attributeNamedArguments = typeof (T).GetCustomAttributesData()
    		.Select(x => x.NamedArguments.SingleOrDefault(ConfigurationNameQuery));
    
    	var contractName = attributeNamedArguments.Single(ConfigurationNameQuery).TypedValue.Value.ToString();
    	return contractName;
    }
    
    Func<CustomAttributeNamedArgument, bool> ConfigurationNameQuery
    {
    	get { return x => x.MemberInfo != null && x.MemberInfo.Name == "ConfigurationName"; }
    }
