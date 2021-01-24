public class CustomerList {
  [JsonProperty("custlist")]
   public Customer[] Customers { get; set; }
}
public class Customer
{
    [JsonProperty("cust_name")]
    public string Name { get; set; }
    [JsonProperty("cust_id")]
    public string Id { get; set; }
}
var sample = "{\"custlist\":[{\"cust_name\":\"Vincent\"},{\"cust_id\":\"klq206f3872d08m92t6\"},{\"cust_name\":\"Joyce\"},{\"cust_id\":\"125g1474grx2d03t9dld\"}]}";
var result = JsonConvert.DeserializeObject<CustomerList>(sample).Customers;
// Or!
var dictResult = JsonConvert.DeserializeObject<Dictionary<string, Customer[]>>(sample)["custlist"];
