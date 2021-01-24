    public ActionResult Add()
    {
    	List<Location> listObj = LocDrpDwnList();
    	/*
    	 // Doesn't hurt populating SelectListItem this way. But you don't need to do this here. 
    	List<SelectListItem> LocList = new List<SelectListItem>();
    
    	foreach (var item in listObj)
    	{
    		LocList.Add(new SelectListItem
    		{
    			Text = item.LocationName.ToString(),
    			Value = Convert.ToInt32(item.LocID).ToString()
    		});
    	}
    	*/
    	ViewBag.LocID = (string?)null; //Set to some predefined locId selection, so when page is loaded, dropdown will be defaulted to this value.
    	ViewBag.LocList = LocList;
    	
    	return View();
    }
