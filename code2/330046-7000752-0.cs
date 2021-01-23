    IOC.Container.RegisterType<IModel1Repository, GenericRepository>();
    IOC.Container.RegisterType<IModel2Repository, GenericRepository>();
    
    interface IModel1Repository : IRepository
    interface IModel2Repository : IRepository
    
    class GenericRepository : IModel1Repository
    {
       // Model1 specific ObjectContext 
    }
    
    class GenericRepository : IModel2Repository
    {
       // Model2 specific ObjectContext
    }
