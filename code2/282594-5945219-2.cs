	[HttpPost]
	public ActionResult Create(OrderCreateViewModel model)
	{
		if(!ModelState.IsValid)
		{
		  return View(model);
		}	
	
		// Persistance logic and return view
		
		var orderToCreate = new Order();
		
		//Build an AutoMapper map
		Mapper.CreateMap<OrderCreateViewModel, Order>();
		//Map View Model to object(s)
		Mapper.Map(model, orderToCreate);		
		
		//Other specialized mapping and logic
		
		_orderService.Create(orderToCreate);
		
		//Handle outcome. return view, spit out error, etc.
	}  
				
