    public class ObjectFactory<T> {
        public static TRepository GetRepositoryInstance<TRepository>() 
          where TRepository : IRepository<T>, new() {
            return new TRepository();
        }
    }
