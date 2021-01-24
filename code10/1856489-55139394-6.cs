    interface IReadOnlyRepository : IDisposable
    {
         IQueryable<IReadOnlyCustomer> Customers {get;}
         IQueryable<IReadOnlyOrders> Orders {get;}
    }
    interface IRepository : IDisposable
    {
         ISet<ICustomer> Customers {get;}
         ISet<IOrder> Orders {get;}
         void SaveChanges();
    }
