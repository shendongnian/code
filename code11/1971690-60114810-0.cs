    void Main()
    {
	    var context = new MongoContext();
	    var filter = Builders<User>.Filter.Empty;
	    var users = context.User.Find(filter).ToList();
	    users.Dump();
    }
    public class MongoContext
    {
	    private static readonly IMongoDatabase Database;
	    static MongoContext()
	    {
		    var connectionString = "mongodb://localhost:27017";
		    IMongoClient client = new MongoClient(connectionString);
		    Database = client.GetDatabase("your_databse_name");
	    }
	    public IMongoCollection<User> User =>
		    Database.GetCollection<User>("your_collection_name");
    }
