    [GridAction]
    [HttpPost]
    public ActionResult Index(GridCommand command)
    {
    
        
        //Change the query here using post back variables
        IEnumerable<Order> data = GetDataByCategory(command);
        var dataContext = new NorthwindDataContext();
    
        //Required for pager configuration
        ViewData["total"] = dataContext.Orders.Count();
    
        return View(data);
    }
