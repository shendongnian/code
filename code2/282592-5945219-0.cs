    [HttpGet]
	public ViewResult Create()
	{
		var vm = new OrderCreateViewModel { 
										     Customers = _customersService.All();  
                                             //An option, not the only solution; for simplicities sake
											 CustomerId = *some value which you might already know*; 
                                             //If you know it set it, if you don't use another scheme.
										  }							  
		return View(vm);	
	}
	[HttpPost]
	public ActionResult Create(OrderCreateViewModel model)
	{
		// Persistance logic and return view
	}  
