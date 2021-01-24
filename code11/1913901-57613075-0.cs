    [HttpPost]
    public ActionResult SetYear (Int32 intYear)
    {
        System.Web.HttpContext.Current.Session["Year"] = intYear;
        return View();
    }
