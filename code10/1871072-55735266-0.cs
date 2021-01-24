    public ActionResult Index()
    {
        ViewModel vm = new ViewModel();
        vm.carrierlist = db.Carriers.ToList();
        return View(vm);
    }  
