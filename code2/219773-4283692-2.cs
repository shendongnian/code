    interface ICustomerRepository
    {
      // Get by id
      Customer Get(int id);
      void Delete(Customer customer);
      IList<Customer> GetAll();
      // creates a new instance in datastore
      // returns the persistent identifier
      int Save(Customer customer);
      // updates if customer exists,
      // creates if not
      //returns persistent identifier
      int SaveOrUpdate(Customer customer);
      // updates customer
      void Update(Customer customer);
      
      // specific queries
      IList<Customer> GetAllWithinFiscalYear(DateTime year);
      // ...
    }
