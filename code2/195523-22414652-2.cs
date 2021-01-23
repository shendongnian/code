    public ActionResult Index()
    {
        ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
        //This will return a partial if partial=true is passed in the querystring.
        return View();
    }
