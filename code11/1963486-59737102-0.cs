    private List<tempObject> temp;
    
    public IActionResult Index([DataSourceRequest] DataSourceRequest request, FilterOptions filterOptions)
    {
        temp = spAccessLayer.GetTempOptions(filterOptions, UserProfile.GetID());
    
        return View();
    }
    
    public IActionResult GetOptions()
    {
    	temp = spAccessLayer.GetTempOptions(filterOptions, UserProfile.GetID());
        return Json(temp);
    }
