    public ActionResult CustomerInfo(int customerId)
    {
       // Fetch the customer from the Repository.
       var customer = _repository.FindById(customerId);
    
       // Map domain to ViewModel.
       var model = Mapper.Map<Customer,CustomerViewModel>(customer);
    
       // Return strongly-typed view.
       return View(model);
    }
