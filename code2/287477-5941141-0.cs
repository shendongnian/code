    //
    // GET: /Account/Login
    public ActionResult Login()
    {
        Login model = new Login();
        if (TempData.ContainsKey("Login"))
        {
             ModelStateDictionary externalModelState = (ModelStateDictionary)TempData["Login"];
             foreach (KeyValuePair<string, ModelState> valuePair in externalModelState)
             {
                 ModelState.Add(valuePair.Key, valuePair.Value);
             }
        }
        return View("_LoginHome", model);
    }
    // 
    // POST: /Account/Login
    [HttpPost]
    public ActionResult Login(Login model)
    {
        if (Request.IsAuthenticated)
        {
            return RedirectToAction("Index", "User", new { id = HttpContext.User.Identity.Name });
        }
        else
        {
            if (ModelState.IsValid)
            {
                if (model.ProcessLogin())
                {
                    return RedirectToAction("Index", "User", new { id = HttpContext.Session["id"] });
                }
            }                
        }
        TempData.Remove("Login");
        TempData.Add("Login", ModelState);
        // If we got this far, something failed, redisplay form
        return RedirectToAction("Index", "Home");
    }
