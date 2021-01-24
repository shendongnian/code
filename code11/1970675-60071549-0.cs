C#
var filter = MongoDB.Driver.Builders<Order>.Filter.AnyIn("products.id", productIds);
Once you get the order list, you can query the product list by LINQ.
Here is my example:
C#
class Program
{
    static void Main(string[] args)
    {
        var client = new MongoClient("{connection string}");
        var database = client.GetDatabase("{database}");
        var collection = database.GetCollection<Order>("{collection}");
        ConventionRegistry.Remove("__defaults__");
        var productIds = new List<int> { 1,2 };
        var filter = Builders<Order>.Filter.AnyIn("products.id", productIds);
        var orders = collection.Find(filter).ToList();
        var products = orders.SelectMany(o => o.Products).Where(p => productIds.Contains(p.Id));
    }
}
class Product
{
    [BsonElement("id")]
    public int Id { get; set; }
    [BsonElement("name")]
    public string Name { get; set; }
}
class Order
{
    [BsonElement("id")]
    public int Id { get; set; }
    [BsonElement("comment")]
    public string Comment { get; set; }
    [BsonElement("products")]
    public List<Product> Products { get; set; }
}
