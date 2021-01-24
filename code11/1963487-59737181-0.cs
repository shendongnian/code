    public IActionResult Index([DataSourceRequest] DataSourceRequest request, FilterOptions filterOptions)
    {
        Session[someKey] = spAccessLayer.GetTempOptions(filterOptions, UserProfile.GetID());
    
        return View();
    }
    
    public IActionResult GetOptions()
    {
        return Json(Session[someKey]);
    }
