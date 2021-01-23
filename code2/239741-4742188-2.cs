    abstract class Repository<T> {
         IEnumerable<T> GetAll();
    }
    abstract class SqlRepository<T> : Repository<T> {
        protected readonly SqlConnection connection;
        public SqlRepository(SqlConnection connection) {
            this.connection = connection;
        }
    }
    class FooRepository : SqlRepository<T> {
        public FooRepository(SqlConnection connection) : base(connection) { }
        public IEnumerable<T> GetAll() {
        }
    }
