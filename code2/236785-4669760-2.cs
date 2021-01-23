    public class ObjectFactory {
        public static TRepository GetRepositoryInstance<T, TRepository>() 
          where TRepository : IRepository<T>, new() {
            return new TRepository();
        }
    }
