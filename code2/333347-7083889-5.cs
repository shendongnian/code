     // Now you don't need StorageLayer, basically it would be IDataService
     // rModel class should provide a some kind of business logic otherwise it just 
     // wrapping with zero value a IDataService and will have 
     // a mess introducing model class per entity
     public sealed class CustomerModel 
     {
        private readonly IDataService 
        
        // now you can inject any an other data service without model changes
        // XmlDataService, WebDataService, etc
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
    
            ICustomer c = this.dataService.SelectEntity<Customer>(id);
            // ...
        }
     }
