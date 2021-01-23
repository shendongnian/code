    routes.MapRoute(
    	"PostRoute", // Route name
    	"{controller}/{id}-{postName}", // URL with parameters
    	new { controller = "Home", action = "Index", id = UrlParameter.Optional, postName = UrlParameter.Optional } // Parameter defaults
    );
    public ActionResult Index(int id, string postName)
    {
    	return View();
    }
