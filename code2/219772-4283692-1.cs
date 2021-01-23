    interface IRepository<TId, TEntity>
    {
      // Get by id
      TEntity Get(TId id);
      void Delete(TEntity entity);
      IList<TEntity> GetAll();
      // creates a new instance in datastore
      // returns the persistent identifier
      TId Save(TEntity entity);
      // updates if customer exists,
      // creates if not
      //returns persistent identiefier
      TId SaveOrUpdate(TEntity entity);
      // updates customer
      void Update(TEntity entity);
    }
    interface ICustomerRepository : IRepository<int, Customer>
    {
      // specific queries
      IList<Customer> GetAllWithinFiscalYear(DateTime year);
    }
