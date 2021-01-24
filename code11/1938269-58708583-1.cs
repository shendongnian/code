    public class User
    {
        public ObjectId _id { get; set; }
        public List<ObjectId> OrganisationIds { get; set; }
    }
    public class UserAggregate
    {
        public List<ObjectId> OrganisationIds { get; set; }
        public ObjectId _id { get; set; }
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
    var instances2 = db.GetCollection<Organisation>("Organisations");
    var aggregation = instances.Aggregate().Match(...).Lookup(foreignCollection: instances2,
            localField: x => x.OrganisationIds, foreignField: x => x._id,
            @as: (UserAggregate pr) => pr.Organisations)
        .ToList();
