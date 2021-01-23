    public ActionResult LogOn(LogOnModel model)
    {
       //Handle custom authorization then call the FormsAuthentication provider
       FormsAuthentication.SignIn(/*userName*/);
       //Return view
    }
