    IUnitOfWork unitOfWork = new EFUnitOfWork();
    
    IRepository<Customer> customerRepository = new CustomerEFRepository(unitOfWork);
    
    Customer c = new Customer();
    
    // init customer
    
    customerRepository.Add(c);
    unitOfWork.Commit();
