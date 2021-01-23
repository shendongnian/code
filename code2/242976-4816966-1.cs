    public ActionResult Index(string mainnav, string subnav)
    {
        ViewBag.MainNav = mainnav;
        ViewBag.SubNav = subnav;
        return View();
    }
