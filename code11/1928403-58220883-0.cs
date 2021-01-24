    DefaultContractResolver contractResolver = new DefaultContractResolver
    {
    	NamingStrategy = new SnakeCaseNamingStrategy()
    };
    
    var response = JsonConvert.DeserializeObject<Response>(json, new JsonSerializerSettings
    {
    	ContractResolver = contractResolver
    });
