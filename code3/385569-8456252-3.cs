    public ActionResult Create(){
        // the name in the ViewBag should match 
        // the property you want to have a list on 
        ViewBag.Type = repository
                       .AddressTypes
                       .ToList()
                       .Select(p => new SelectListItem { 
                                        Key = p.Id, 
                                        Value = p.Description});
        ViewData.Model = new BetterTestClass();
        return View();
    }
