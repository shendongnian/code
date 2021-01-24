    [HttpPost]
    public ActionResult Edit(EditViewModel model)
    {
         TempData["EditViewModel"] = model;
    
         if (ModelState.IsValid)
         {
            //Do Something                
         }
         var model1 = new IndexViewModel();
         ModelState.AddModelError("", "An error occurred while editing the user.");
         return RedirectToAction("Index", model1);
    }
     [HttpGet]
    public ActionResult Index(IndexViewModel model)
    {
      model = TempData["IndexViewModel"] as IndexViewModel;                
      IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
    }
