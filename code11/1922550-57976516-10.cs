    public ActionResult Index()
    {
    	// The key, "GetStringResult" is arbitrary. 
    	// Whatever value you assign to this key can be accessed from the view using the same key.
    	ViewState["GetStringResult"] = GetString();
    	return View();
    }
    
    private string GetString() 
    {
    	return "Hi string";
    }
    
