    public ActionResult Index()
    {
        IEnumerable<MemberViewModel> model = ...
        return View(model);
    }
