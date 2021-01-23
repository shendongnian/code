    private IDataContext _datacontext;   
    public CustomerService(IDataContext dataContext)   
    {   
       _dataContext = dataContext;  
    }
    
    public AddCustomer(Customer entity)   
    {   
      this._dataContext.Customers.Add(entity);
      this._dataContext.SaveChanges;   
    }   
