    abstract class Repository<T> {
         IEnumerable<T> GetAll();
    }
    public class FooRepository : Repository<T> {
        private readonly SqlConnection connection;
        public FooRepository(SqlConnection connection) {
            this.connection = connection;
        }
        public IEnumerable<T> GetAll() {
        }
    }
