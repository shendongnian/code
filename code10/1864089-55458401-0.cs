    public class MongoDBConnect : IDisposable
    {
        public IMongoClient client;
        public IMongoDatabase database;
        public MongoDBConnect()
        {
            client = new MongoClient("mongodb://localhost");
            database = client.GetDatabase("dbo");
        }
        public void Dispose()
        {
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
