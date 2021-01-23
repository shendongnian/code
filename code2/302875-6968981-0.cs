    public ActionResult Create()
    {
        var viewModel = new Store();
        var storeTypes = new SelectList(
                            (   
                                from t in _db.StoreTypes
                                select new SelectListItem
                                {
                                    Text  = t.StoreTypeName,
                                    Value = SqlFunctions.StringConvert((double)t.StoreTypeID) //convert int to string (yikes)
                                }
                            )
                            , "Value", "Text");
        
        ViewData["StoreTypes"] = storeTypes;    
         return View(viewModel);
    } 
