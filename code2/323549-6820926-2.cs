    public ActionResult Index(int? newPage)
    {
        var model = ... fetch the products corresponding to the given page number
        return PartialView(model);
    }
