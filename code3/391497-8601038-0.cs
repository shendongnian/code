    private MyEntities db = new MyEntities();
    public ViewResult Index()
    {
        var model = db.Items.ToList().Select(x => GetUserFromGuid(x.AssignedTo));
        return View(model);
    }
