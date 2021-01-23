    public ActionResult LogOn(LogOnModel model)
    {
       //Handle custom authorization then call the FormsAuthentication provider
       FormsAuthentication.SetAuthCookie(/*user name*/, true);
       //Return view
    }
