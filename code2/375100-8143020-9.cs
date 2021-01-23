    [AutoMap(typeof(IEnumerable<DomainModel>), typeof(IEnumerable<MyViewModel>))]
    public ActionResult Index()
    {
        IEnumerable<DomainModel> data = ...
        return View(data);
    }
