    void Main()
    {
	    var context = new MongoContext();
	    var filter = Builders<User>.Filter.Empty; // Finds all
        //var filter = Builders<User>.Filter.Eq(x => x.Id, ObjectId.Parse("5bedfd60502d2c2854d43e6f"));
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
