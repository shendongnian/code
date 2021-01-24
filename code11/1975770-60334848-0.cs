    public ActionResult LogOn() 
    {
        GenericIdentity gi = new GenericIdentity("Bob", "Passport");
        HttpContext.User = new GenericPrincipal
        (
           gi,
           new[] { "managers", "executives" }
        );
        FormsAuthentication.SetAuthCookie(User.Identity.Name, false);
        return View("Index");
    }
