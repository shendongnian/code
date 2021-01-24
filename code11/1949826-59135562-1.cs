    public async System.Threading.Tasks.Task<JObject> ExecuteSystemObject(string parameters)
	{    
	    try 
	    {
	    	dynamic j = await ExternalProject.ExecuteSomething<MyModel>(parameters);
		    //How i can catch the error from the another class?
		    ...
		}
	    catch(Exception e)
	    {
	    	//WebException will be caught here
	    }
	}
	public async Task<Object> ExecuteSomething<T>() where T : IModel, new()
	{
	    try 
	    {
	    	WebResponse response = await ExternalProject.ExecuteRequestAsync(PostRequest);
		}
	    catch(Exception)
	    {
	    	throw;
	    }
	    
	}
	public static async Task<WebResponse> ExecuteRequestAsync(WebRequest request)
	{
	    try
	    {
	        //return await request.GetResponseAsync();
	        throw new WebException("Test error message");
	    }
	    catch(WebException e)
	    {
	        throw;
	    }
	}
