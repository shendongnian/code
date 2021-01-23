    public ActionResult Index()
    {
        IEnumerable<FooModel> items = ...
        var viewModel = new MyViewModel
        {
            Items = Mapper.Map<IEnumerable<FooModel>, IEnumerable<SelectListItem>>(items)
        };
        return View(viewModel);
    }
