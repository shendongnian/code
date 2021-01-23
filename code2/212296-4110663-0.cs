    public ActionResult Index()
    {
        var viewModel = new CarViewModel();
        viewModel.Colors = new SelectList(colorRepository.GetAll(),"Id","Name");
        viewModel.Car = new Car();
        return View(viewModel);
    }
