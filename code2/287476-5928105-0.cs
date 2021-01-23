    [HttpPost]
    public ActionResult LogIn(Login model)
    {
        if (Request.IsAuthenticated)
        {
            return RedirectToAction(model.ReturnUrl);
        }
        else
        {
            if (ModelState.IsValid)
            {
                if (model.ProcessLogin())
                {
                    return RedirectToAction(model.ReturnUrl);
                }
             }
         }
    
         // If we got this far, something failed. Return the generic SiteAuthenticate view
         var saModel = new SiteAuthModel { LoginModel = model };
         return View("~/Views/Account/SiteAuthenticate.cshtml", saModel);
    }
