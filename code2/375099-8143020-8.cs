    public ActionResult Index()
    {
        IEnumerable<DomainModel> data = ...
        var viewModel = Mapper.Map<IEnumerable<DomainModel>, IEnumerable<MyViewModel>>(data);
        return View(viewModel);
    }
