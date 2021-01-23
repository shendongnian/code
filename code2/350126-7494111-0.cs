    public ActionResult PewPew()
    {
        MyModel model;
    	const string cacheKey = "resource";
    	lock (controllerLock)
    	{
    		if (HttpRuntime.Cache[cacheKey] == null)
    		{
    			HttpRuntime.Cache.Insert(cacheKey, LoadExpensiveResource());
    		}
    		model = (MyModel) HttpRuntime.Cache[cacheKey];
    	}
    
    	return View(model);
    }
