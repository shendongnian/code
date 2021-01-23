    public ActionResult Index(int? pageSize)
    {
        MyViewModel model = new MyViewModel();
    
        foreach(var sheet in Model.Sheets.Take(pageSize != null ? pageSize : 20))
        {
            //yada yada yada. Do something here with sheet and model.
        }
    
        return View(model);
    }
