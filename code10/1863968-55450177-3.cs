    public ActionResult Index()
    {
       SimpleViewModel viewModel = new SimpleViewModel();
       viewModel.Status_List = // Initialize it here.
       viewModel.Default_Status = // If you want to Change you Default_Status.
       
       return view(viewModel);
    }
