    public class Instance
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public ObjectId TemplateId { get; set; }
        // mind that it's array. If you have 1 template per Instance, it's a 1 element array.
        public Template[] Template { get; set; }
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
    var templates = db.GetCollection<Template>("Templates");
    var resultOfJoin = instances.Aggregate()
        .Lookup(foreignCollection: templates, localField: x => x.TemplateId,
        foreignField: x => x.Id, @as: (Instance pr) => pr.Template).ToList();
