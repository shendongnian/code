    public class RepositoryFactory : IRepositoryFactory
    {
        public IRepository<T> CreateNewRepository<T>()
        {
            return ObjectFactory.GetInstance(typeof(Repository<T>));
        }
    }
