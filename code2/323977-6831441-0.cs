    public ActionResult Index()
    {
      var viewModel = new MyViewModel();
    
      viewmodel.EmailBody = "Default";
    
      return this.View(viewModel);
    }
    [HttpPost]
    public ActionResult Index(MyViewModel inputViewModel)
    {
      string body = inputViewModel.EmailBody // Whatever....
    }
