    [HttpGet]
    public IActionResult Index()
    {
    	var model = new IndexVM();
    	return View(model);
    }
    
    [HttpPost]
    public IActionResult Index(IndexVM model)
    {
    	// you can do something with the parameters from the models here, or some other stuff
    	return View(model);
    }
