    public void ProcessRequest(HttpContext context) 
    { 
    	//Detect Http Method
    	if(context.Request.HttpMethod == "POST")
    	{
    		//Get the posted values
    		int val1 = context.Request["key1"];
    		int val2 = context.Request["key2"];
    		
    		//... your logic
    		
    		//send the response back with http status code
    	}
    }
