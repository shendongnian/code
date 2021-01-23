    routes.MapRoute(
        "SEORoute", // Route name
        "{category}/{page_name}", // URL with parameters
        new { controller = "Home", action = "Index", category = UrlParameter.Optional, pagename = UrlParameter.Optional } // Parameter defaults
    );
    public ActionResult Index(string category, string page_name) {
        //same as before but instead of looking for id look for pagename
    }
