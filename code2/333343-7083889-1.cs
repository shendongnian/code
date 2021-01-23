     // here is I used few types defined below
     // now you don't need StorageLayer, basically it would be IDataService
     // here is shold be some kind of business logic otherwise it just 
     // wrapping with zero value a IDataService and will have 
     // a mess introducing model class per entity
     public sealed class CustomerModel 
     {
        private readonly IDataService dataService;
    
        public CustomerModel (IDataService dataService)
        {
            this.dataService = dataService;
        }
    
        public ICustomer GetCustomer(int id)
        {
            if (id < 0) 
            {
               throw new ArgumentException("id", 
                                      "Id should be equal or greater than zero");
            }
    
            ICustomer c = this.dataService.ReadEntity<Customer>(id);
            // ...
        }
     }
