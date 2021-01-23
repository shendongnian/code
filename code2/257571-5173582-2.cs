    [CanvasAuthorize]
    public ActionResult Index()
    {
    	var app = new FacebookClient(new Authorizer().Session.AccessToken);
    
    	dynamic me = app.Get("me");
    	ViewBag.Firstname = me.first_name;
    	ViewBag.Lastname = me.last_name;
    
    	return View();
    }
