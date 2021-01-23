    [HttpPost]
    public ActionResult LogOn([ModelBinder(typeof(MyCustomModelBinder))] object Model, string returnUrl)
    {
        if (Model is RegisterModel)
        {
            Register((RegisterModel)Model, returnUrl);
        }
        return View();
    }
 
