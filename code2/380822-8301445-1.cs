    [HttpPost]
    public ActionResult Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            if (Authenticate(model.Username, model.Password))
            {
                // authentication was successful. The method created the cookie
                // so we can safely redirect to an authenticated page here
                return RedirectToAction("Index");
            }
            else
            {
                // authentication failed due to wrong username or password =>
                // we add an error message to the ModelState here so that we 
                // can show it in the view
                ModelState.AddModelError("", "Wrong username and password");
            }
        }
        // At this stage we know that some error happened =>
        // we redisplay the view so that the user can fix it
        return View(model);
    }
    private bool Authenticate(string userName, string password)
    {
        const string commaSeperatedRoles = "Administrator,Editor";
        if (userName == "xx" && password == "xxx")
        {
            // Warning: you should not be redirecting here. You should only
            // create and set the authentication cookie. The redirect should be done
            // in an MVCish way, i.e. by returning a RedirectToAction result if this
            // method returns true
            FormsAuthenticationUtil.SetAuthCookie(userName, commaSeperatedRoles, false);
            return true;
        }
        // wrong username or password
        return false;
    }
