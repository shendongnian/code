    interface IRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Save(T t);
    }
    
    class BaseRepository<T> : IRepository<T>
    {
       ... // implement common methods
    }
    
    interface IProductRepository : IRepository<T>
    {
        IEnumerable<T> GetTop5BestSellingProducts();    
    }
    
    class ProductRepository : BaseRepository<T>, IProductRepository 
    {
        ... // implement important methods
    }
