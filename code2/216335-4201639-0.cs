    public ActionResult Index()
    {
        var viewModel = new ViewModel();
        viewModel.ScenarioName = "Scenario1";
        return View(viewModel);
    }
