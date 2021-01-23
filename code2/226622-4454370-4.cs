    // The concrete implementation of this interface will handle connections to the
    // database
    public interface IDatabase
    {
        SqlDataReader ExecuteQuery(SqlCommand command);
    }
    public interface IEntityMapper<T>
    {
        T MapAll(SqlDataReader reader);
    }
    public abstract class EntityRepository<T>
    {
        private readonly IDatabase _database;
        private readonly IEntityMapper<T> _mapper;
        protected EntityRepository(IEntityMapper<T> mapper, IDatabase database)
        {
            _mapper = mapper;
            _database = database;
        }
        public T Get(int id)
        {
            return this.Get(_mapper, _database, id);
        }
        protected virtual T Get(IEntityMapper<T> mapper, IDatabase database, int id)
        {
            // Create a command can be used to fetch the entity, remember to dispose when complete
            using (var cmd = this.CreateGetCommand(id))
            {
                using (var reader = database.ExecuteQuery(cmd))
                {
                    // No need to read all the rows, just the first...
                    return reader.Read() ? mapper.MapAll(reader) : default(T);
                }
            }
        }
        protected abstract SqlCommand CreateGetCommand(int id);
    }
