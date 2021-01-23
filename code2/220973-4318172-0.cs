    public ActionResult Step1()
    {
        var customer = _customerService.GetCustomer();
        var appointment = _appointmentService.GetAppointmentFor(customer);
        
        var viewModel = new Step1ViewModel(customer, appointment);
        return View(viewModel);
    }
