    public class RootObject
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("errorMessage ")]
        public object ErrorMessage { get; set; }
        [JsonProperty("data")]
        public Data Data { get; set; }
    }    
    public class Data
    {
        public List<Order> Orders { get; set; }
    }
    public class Order
    {
        public int OrderID { get; set; }
        public int FacilityID { get; set; }
        public string FacilityOrderID { get; set; }
        public string StatusID { get; set; }
        public bool Contract { get; set; }
        public bool PermPlacement { get; set; }
    }
and you would **deserialize your json** to the `RootObject`, like so.
string json = @"
{
""success"": true,
""errorMessage"": null,
""data"": {
        ""Orders"": [
            {
            ""OrderID"": 4914194,
            ""FacilityID"": 1398,
            ""FacilityOrderID"": """",
            ""StatusID"": ""F"",
            ""Contract"": true,
            ""PermPlacement"": false,
    }]}}
";
    var obj = JsonConvert.DeserializeObject<RootObject>(json);
    List<Order> allOrders = obj.Data.Orders;
Once you have deserialized your json, you can access the Orders and do what you need to do with them.
