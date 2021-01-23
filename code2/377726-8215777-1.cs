    public override void Configure(Container container)
    {
    	//Permit modern browsers (e.g. Firefox) to allow sending of any REST HTTP Method
    	base.SetConfig(new EndpointHostConfig
    	{
    		GlobalResponseHeaders =
    			{
    				{ "Access-Control-Allow-Origin", "*" },
    				{ "Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS" },
    			},
    	});
    }
