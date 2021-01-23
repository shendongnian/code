    public ActionResult Index()
    {
       ViewData["Optin"] = True;
    }
    
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Index(FormCollection form, bool OptIn )
    {        
        ViewData["Optin"] = OptIn;
    }
