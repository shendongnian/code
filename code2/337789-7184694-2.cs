    public ActionResult Index()
    {
        var httpParams = ParamsWrapper.Instance;
        return new CustomActionResult(this);
    }
