    [HttpPost]
    public ActionResult Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            if (Authenticate(model.Username, model.Password))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Wrong username and password");
                return View(model);
            }
        }
        else
        {
            return View(model);
        }
    }
    private bool Authenticate(string userName, string password)
    {
        const string commaSeperatedRoles = "Administrator,Editor";
        if (userName == "xx" && password == "xxx")
        {
            // Warning: you should not be redirecting here. You should only
            // set the authentication cookie. The redirect should be done
            // in an MVCish way, i.e. by returning a RedirectToAction result
            FormsAuthenticationUtil.SetAuthCookie(userName, commaSeperatedRoles, false);
            return true;
        }
        return false;
    }
