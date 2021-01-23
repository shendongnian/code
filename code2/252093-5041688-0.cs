    interface IRepository<in T> where T : IBusinessEntity
    {
        void Save(T t);
        void Delete(T t);
    }
