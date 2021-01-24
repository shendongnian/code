    private List<WorkOrder> CreateWorkOrders()
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
        return workOrders; 
    }
    
    public IActionResult GetWorkOrdersByLocation(string locationid)
    {
        var workOrders CreateWorkOrders();
        locationWorkOrders = workOrders.Where(x => x.LocationId == locationid).ToList();
        return View(locationWorkOrders); 
    }
