    public class User
    {
        public ObjectId _id { get; set; }
        public List<ObjectId> OrganisationIds { get; set; }
        public List<Organisation> Organisations { set; get; }
    }
    public class Organisation
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
    }
    string connectionString = "mongodb://localhost:27017";
    var client = new MongoClient(connectionString);
    var db = client.GetDatabase("test");
    var instances = db.GetCollection<User>("Users");
    var aggregation = instances.Aggregate().Lookup("Organisations", "OrganisationIds", "_id", "Organisations");
    var firstUser = aggregation.FirstOrDefault();
    var user = BsonSerializer.Deserialize<User>(firstUser);
