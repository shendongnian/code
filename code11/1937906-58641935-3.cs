    public class Instance
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public ObjectId TemplateId { get; set; }
        public Template Template { get; set; }
    }
    public class Template
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
    string connectionString = "mongodb://localhost:27017";
    var client = new MongoClient(connectionString);
    var db = client.GetDatabase("test");
    var instances = db.GetCollection<Instance>("Instances");
    var resultOfJoin = instances.Aggregate()
        .Lookup("templates", "templateId", "_id", @as: "template")
        .Unwind("template")
        .As<Instance>()
        .ToList();
