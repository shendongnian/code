    public class ObjectFactory<T>
    {
        public static IRepository<T> GetRepositoryInstance()
        {
            return new Repository<T>();
        }
    }
