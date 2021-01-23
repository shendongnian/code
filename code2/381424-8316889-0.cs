    [HttpPost]
    public ActionResult LogOn(object Model, string returnUrl)
    {
        if (Model is RegisterModel)
        {
            Register((RegisterModel)Model, returnUrl);
        }
        return View();
    }
 
