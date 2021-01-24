    interface IReadOnlyCustomer : IId
    {
        string Name {get;}
        ...
    }
    interface ICustomer : IRepositoryItem
    {
        string Name {get; set;}
    }
    class Customer : RepositoryEntity<Customer>, IReadOnlyCustomer, ICustomer
    {
         // Interfaces IId and IRepositoryItem implemented by base class
        
         // Interface ICustomer
         public string Name {get; set;}
         ...
         // Interface IReadOnlyCustomer
         string IReadOnlyCustomer.Name => this.Name;
         ...
    }
