     [HttpPost]
     public ActionResult New(NewCongressViewModel viewModel)
     {
       var complexObj = JsonConvert.SerializeObject(viewModel);
       TempData["mymodel"] = complexObj;
       return RedirectToAction("New");
     }
    public ActionResult New()
    {
        if (TempData["mymodel"] is string complexObj )
        {
            var getModel= JsonConvert.DeserializeObject<NewCongressViewModel>(complexObj); //Your model values can now be accessed
        }
        return View();
    }
