    public interface IRepositoryFactory<T>
    {
        IRepository<T> Create();
    }
    public class RepositoryFactory<T> : IRepositoryFactory<T>
    {
        public IRepository<T> Create()
        {
            var repo = ObjectFactory.GetInstance<IRepository<T>>();
            repo.Foo();
            return repo;
        }
    }
