    public interface IUnitOfWork:IDisposable
    {
        int SaveChanges();
    }
    public interface IDALContext : IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
    }
