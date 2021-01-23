    public ActionResult Home()
    {
        PopulateWrapper(GetTagData()); // after defining an overload in base
        return View();
    }
