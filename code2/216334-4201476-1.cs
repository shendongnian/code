    public ActionResult Index()
    {
        var viewModel = new ViewModel();
        viewModel.ShowButton1 = condition1 && condition2;
        viewModel.ShowButton2 = condition3 && condition4;
    }
