    public ActionResult Index(int? wholesalerID, string type)
    {
	    if (!string.IsNullOrEmpty(type)) {
		    //APPLY YOUR LOGIC TO ORDER BY ANY TYPE YOU PASS IN THIS PARAMETER, LIKE 'OSI'
	    }
	    else {
		    //REGULAR ORDERING ALREADY IN USE
	    }
	
	    ...
	    return View(salesOrders.Take(perpage).ToList());
    }
