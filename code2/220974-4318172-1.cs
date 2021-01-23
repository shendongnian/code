    public MyController(IUnitOfWork unitOfWork)...
    
    public ActionResult Step1()
    {
        var customer = unitOfWork.Find<Customer>();
        var viewModel = new Step1ViewModel(customer.Appointment);
        return View(viewModel);
    }
