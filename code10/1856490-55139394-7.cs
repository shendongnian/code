    class Repository : IReadOnlyRepository,     // Query Only
     IRepository,                               // Query, Add and Update
     IDisposable
    {
         private readonly dbContext = new CustomerDbContext();
         // TODO: Dispose() will Dispose dbContext
         // Used by the other interfaces
         protected IDbSet<Customer> Customers => this.dbContext.Customers;
         protected IDbSet<Orders> Orders => this.dbContext.Orders;
         void SaveChanges() {this.dbContext.SaveChanges();}
         // IRepository:
         ISet<ICustomer> IRepository.Customers => new Set<Customer>{DbSet = this.Customers};
         ISet<IOrder> IRepository.Orders => new Set<Order>{DbSet = this.Orders};
         void IRepository.SaveChanges() {this.DbContext.SaveChanges();}
         // IReadOnlyRepository
         IQueryable<IReadOnlyCustomer> IReadOnlyRepository.Customers => this.Customers;
         IQueryable<IReadOnlyOrders> IReadOnlyRepository.Orders => this.Orders;
    }
        
