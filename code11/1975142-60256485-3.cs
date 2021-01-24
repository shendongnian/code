var obj = JObject.Parse(json);
foreach(var order in obj["Orders"])
{
    Console.WriteLine(order["OrderId"]);
}
or you can use the Where clause.
var myOrder = obj["Orders"].Where(x => x["OrderId"].ToString().Equals("87654")).FirstOrDefault();
Then you can print any property of that order,
Console.WriteLine(myOrder["OrderDetails"]["Name"].ToString());
// Prints: Desk
---
**Alternatively, you can:** also use classes to deserialize the json you have and query the orders.
public class OrderDetails
{
    public string OrdId { get; set; }
    public string Name { get; set; }
}
public class Order
{
    public string OrderId { get; set; }
    public OrderDetails OrderDetails { get; set; }
}
public class RootObject
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<Order> Orders { get; set; }
}
public static void Main(string[] args) 
{
    string json = File.ReadAllText(@"C:\temp\json.txt");
    var obj = JsonConvert.DeserializeObject<RootObject>(json);
    var myOrder = obj.Orders.FirstOrDefault(x => x.OrderId.Equals("87654"));
    if (myOrder != null)
    {
        Console.WriteLine(myOrder.OrderDetails.Name);
    }
}
