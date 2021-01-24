    public class MongoContext<T>
    {
        private readonly IMongoDatabase _database = null;
        private readonly string _collection = null;
        public MongoContext(IOptions<MongoSettings> _settings, string collection)
        {
            var client = new MongoClient(_settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(_settings.Value.Database);
            _collection = collection;
        }
        public IMongoCollection<T> Objects
        {
            get
            {
                IMongoCollection<T> dbConnection = _database.GetCollection<T>(_collection);
                return dbConnection;
            }
        }
    }
    public class Repository<T> : IMainMongoRepository<T>, IClientSearching<T>
    {
        private readonly MongoContext<T> mongoContext = null;
        public Repository(MongoContext<T> mongoContext)
        {
            this.mongoContext = mongoContext;
        }
        public async Task AddAsync(T obj)
        {
            try
            {
                await mongoContext.Objects.InsertOneAsync(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<T> GetByIdAsync(string id)
        {
            try
            {
                FilterDefinition<T> filter = Builders<T>.Filter.Eq("Id", id);
                T obj = await mongoContext.Objects.Find(filter).FirstOrDefaultAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
