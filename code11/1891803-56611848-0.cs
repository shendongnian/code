    public IActionResult WorkOrders()
    {
        // get the work order list and return a view on it
        return View(GetWorkOrders()); 
    }
    private List<WorkOrder> GetWorkOrders()
    {
        List<WorkOrder> workOrders = new List<WorkOrder> ();
        workOrders.Add(new WorkOrder { UserId = 1, LocationId = 
    "Philadelphia", Date = DateTime.Now, Reason = "Lights", IsActive = 
    true });
        workOrders.Add(new WorkOrder { UserId = 2, LocationId = "Camden", 
    Date = DateTime.MinValue, Reason = "Plumbing", IsActive = true });
        workOrders.Add(new WorkOrder { UserId = 3, LocationId = 
    "Burlington", Date = DateTime.Now, Reason = "Water", IsActive = 
    false });
        workOrders.Add(new WorkOrder { UserId = 4, LocationId = 
    "Wilmington", Date = DateTime.MaxValue, Reason = "Lights", IsActive 
    = true });
     // return the work orders to be used by your view methods
     return workOrders; 
    }
    public IActionResult GetWorkOrdersByLocation()
    {
        // get your work order list and extract all locations
        var locations = GetWorkOrders().Select(x => x.LocationId).ToList();
        // return view on all locations
        return View(locations); 
    }
