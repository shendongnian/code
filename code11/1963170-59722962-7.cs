    public ActionResult Add()
    {
        List<Location> listObj = LocDrpDwnList();
         
        List<LocationViewModel> LocList = new List<LocationViewModel>();
    
        foreach (var item in listObj)
        {
            LocList.Add(new LocationViewModel
            {
                LocationName = item.LocationName.ToString(),
                LocId  = Convert.ToInt32(item.LocID).ToString()
            });
        }
    /*
        ViewBag.LocID = (string?)null; //Set to some predefined locId selection, so when page is loaded, dropdown will be defaulted to this value.
        ViewBag.LocList = LocList;*/
    
        return View(new AddViewModel{LocList = LocList});
    }
