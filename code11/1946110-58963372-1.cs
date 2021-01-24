    public interface IModelService
    {
        Task<IEnumerable<string>> GetModelsIds();
        Task AddModel();
    }
    public class ModelService : IModelService
    {
        private const string CollectionName = "Models";
        
        private readonly MongoClient client;
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMongoCollection<Model> _modelsCollection;
        
        public ModelService()
        {
            client = new MongoClient("mongodb://localhost:27017");
            _mongoDatabase = client.GetDatabase("MongoStackOverFlow");
            _productsCollection = _mongoDatabase.GetCollection<Model>(CollectionName);
        }
        
        public async Task<IEnumerable<string>> GetModelsIds()
        {
            var models =  await _productsCollection.Find(p => p.ID != null).ToListAsync();
            return models.Select(x => x.ID.ToString());
        }
        public async Task AddModel()
        {
            var model = new Model(new ObjectId());
            await _productsCollection.InsertOneAsync(model);
        }
    }
