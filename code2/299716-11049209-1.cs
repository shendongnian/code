    public ActionResult Shelf(NewCapitalStructureViewModel model)
    {
        if (model == null)             
            model = new NewCapitalStructureViewModel(); 
        ControllerContext.Controller.TempData.Clear();      
        return View("Shelf", model);
    } 
