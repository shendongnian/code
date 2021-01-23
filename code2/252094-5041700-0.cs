    interface IDataSource<out T> where T : IBusinessEntity
    {
        IQueryable<T> GetAll();
    }
    interface IRepository<T> : IDataSource<T> where T : IBusinessEntity
    {
        void Save(T t);
        void Delete(T t);
    }
