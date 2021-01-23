    public ActionResult Index()
    {
      ControllerContext.RouteData.DataTokens.Add("name", "value");
      return View();
    }
