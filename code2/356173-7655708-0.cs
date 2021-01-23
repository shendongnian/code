    public ActionResult Index()
    {
       FormsAuthentication.SignOut(); 
       return new HttpUnauthorizedResult();
    }
