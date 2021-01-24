    [HttpGet]
    public ActionResult Index()
    {
    
    	List<Foo> list = new List<Foo> 
    	{ 
    		new Foo 
    		{
    			IsActive = true,
    			Value = "A: I'm active"
    		},
    		
    		new Foo 
    		{
    			IsActive = false,
    			Value = "B: I'm deactivated"
    		}, 
    	};
    	
    	return View(list);
    }
