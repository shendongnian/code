    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly string tableName;
        public BaseRepository() : this(typeof(TEntity).Name)
        {
        }
        public BaseRepository(string tableName)
        {
            this.tableName = tableName;
        }
        public TEntity GetById(int id)
        {
            return _db.Fetch<TEntity>($"select * from Table{tableName} where id = {id}");
        }
    }
