    public ActionResult Index()
    {
        var viewModel = new MyViewModel();
        viewModel.MyList = db.Magazyn.Include(m => m.Tools).Include(m => m.Person).ToList();
        viewModel.PersonCount = db.Persons.Count();
        return View(viewModel);
    }
