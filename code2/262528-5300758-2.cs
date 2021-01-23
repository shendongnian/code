    [GridAction]
    public ActionResult Index(GridCommand command)
    {
        IEnumerable<Order> data = GetData(command);
        var dataContext = new NorthwindDataContext();
        //Required for pager configuration
        ViewData["total"] = dataContext.Orders.Count();
    
        return View(data);
    }
