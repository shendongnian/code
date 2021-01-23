    public ActionResult Index()
    {
        IEnumerable<IndexModel> model = new List<IndexModel>(); // or from your EF Repository
        return View(model);
    }
