    var order = JsonSerializer.Deserialize<Order>(json);
    // ==>
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public decimal Balance { get; set; }
        public DateTime Opened { get; set; }
        public bool IsActive { get; set; }
        public List<string> Items { get; set; }
    }
    var json = JsonSerializer.Serialize(order);
    // ==>
    {
        "id": 123456,
        "orderNumber": "ABC-123-456",
        "balance": 9876.54,
        "opened": "2019-10-21T23:47:16.85",
        "isActive": true,
        "items": [ "Item1", "Item2", "Item3" ]
    };
