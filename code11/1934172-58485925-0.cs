    public class Category
    {
        public string _id { get; set; }
        public string name { get; set; }
    }
    public class Product
    {
        public string _id { get; set; }
        public string title { get; set; }
        public string[] categories { get; set; }
    }
    public class AggregatedProduct
    {
        [BsonElement("_id")]
        public string Id { get; set; }
        [BsonElement("title")]
        public string Title { get; set; }
        [BsonElement("categories")]
        public Category[] Categories { get; set; }
    }
    string connectionString = "mongodb://localhost:27017";
    var client = new MongoClient(connectionString);
    var db = client.GetDatabase("test");
    var products = db.GetCollection<Product>("Products");
    var categories = db.GetCollection<Category>("Categories");
    var resultOfJoin = products.Aggregate().Lookup(foreignCollection: categories, localField: x => x.categories,
        foreignField: x => x._id, @as: (AggregatedProduct pr) => pr.Categories).ToList();
