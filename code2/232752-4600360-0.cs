    [HttpPost]
    public ActionResult Register(string[] roles)
    {
        if (ModelState.IsValid)
        {
            //save roles
            return RedirectToAction("Index", "Home");
        }
 
        // If we got this far, something failed, redisplay form
        return View(model);
    }
