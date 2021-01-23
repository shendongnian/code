        public class ObjectFactory<T> {
        public static TRepository GetRepositoryInstance<TRepository>(params object[] args) 
          where TRepository : IRepository<T> {
            return (TRepository)Activator.CreateInstance(typeof(TRepository), args);
        }
    }
