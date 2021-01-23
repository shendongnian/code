    public ViewResult BeginFooProcessing(String fooBar)
    {
    	if (Request.IsAjaxRequest())
    	{
    		Guid fooId = Guid.NewGuid();
    
    		var result = new FooResult
    				        {
    				            FooId = fooId,
    				            HasFinishedProcessing = false,
    				            Uris = new List<string>()
    				        };
    
    		// This needs to go to persistent storage somewhere
    		// as subsequent requests may not come back to this
    		// webserver
    		result.SaveToADatabaseSomewhere();
    
    		System.Threading.Tasks.Task.Factory.StartNew(() => ProcessFoo(fooId));
    
    				
    		return View("MyFooStartView", fooId);
    	}
    	throw new InvalidOperationException();
    }
    
    private void ProcessFoo(Guid fooId)
    {
    	// Perform your long running task here
    
    	FooResult result = GetFooResultFromDataBase(fooId);
    
    	result.HasFinishedProcessing = true;
    	result.Uris = uriListThatWasCalculatedAbove;
    
    	result.SaveToADatabaseSomewhere();
    }
    
    public ViewResult CheckFooFinished(Guid fooId)
    {
    	if (Request.IsAjaxRequest())
    	{
    		FooResult result = GetFooResultFromDataBase(fooId);
    
    		if (result.HasFinishedProcessing)
    		{
			// Clean up after ourselves
			result.DeleteFromDatabase();
    			return View("MyFooFinishedView", result.Uris);
    		}
    
    		return View("MyFooFinishedView", null);
    				
    	}
    	throw new InvalidOperationException();
    }
    
    private class FooResult
    {
    	public Guid FooId { get; set; }
    
    	public bool HasFinishedProcessing { get; set; }
    
    	public List<string> Uris;
    }
