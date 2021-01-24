    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IDbConnection _dbConnection;
        public BaseRepository(IDbConnection _dbconn)
        {
            _dbConnection = _dbconn;
        }
        public async Task Add(T entity)
        {
            var result = await _dbConnection.InsertAsync(entity);
        }
        public async Task<bool> Delete(T entity)
        {
            return await _dbConnection.DeleteAsync(entity);
        }
        public async Task<bool> Update(T entity)
        {
            return await _dbConnection.UpdateAsync(entity);
        }
        public async Task<T> GetById(object id)
        {
            return await _dbConnection.GetAsync<T>(id);
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbConnection.GetAllAsync<T>();
        }
    }
