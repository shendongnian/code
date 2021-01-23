    [GridAction]
    [HttpPost]
    public ActionResult Index(GridCommand command)
    {
        desiredCategory = this.myDropDownList.SelectedCategory.ToString();
        //Change the query here using post back variables
        IEnumerable<Order> data = GetData(command);
        data = from x in data.[entity name]
               where x.category = desiredCategory
               select x;
        var dataContext = new NorthwindDataContext();
    
        //Required for pager configuration
        ViewData["total"] = dataContext.Orders.Count();
    
        return View(data);
    }
