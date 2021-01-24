    public class RootObject
    {
        [JsonProperty("d")]
        public D D { get; set; }
    }
        
    public class D
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
and you would **deserialize your json** to the `RootObject`, like so.
string json = @"
{ d: {
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
    }]}}}
";
    var obj = JsonConvert.DeserializeObject<RootObject>(json);
    List<Order> allOrders = obj.D.Data.Orders;
Once you have deserialized your json, you can access the Orders and do what you need to do with them.
