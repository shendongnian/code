    public class RootObject
    {
        public BillingAddress billingAddress { get; set; }
        public string clientId { get; set; }
        public List<Document> documents { get; set; }
        public Dictionary<string, Fulfillment> fulfillments { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
    public class BillingAddress
    {
        public string zip { get; set; }
        public string state { get; set; }
        public string number { get; set; }
        public string status { get; set; }
        public string firstName { get; set; }
        public Telephone telephone { get; set; }
        public string neighbourhood { get; set; }
    }
    public class Telephone
    {
        public string type { get; set; }
        public string number { get; set; }
    }
    public class Document
    {
        public string type { get; set; }
        public string number { get; set; }
    }
    public class Fulfillment
    {
        public string id { get; set; }
        public string orderId { get; set; }
        public string channelId { get; set; }
        public string clientId { get; set; }
        public string locationId { get; set; }
        public Operator @operator { get; set; }
        public string ownership { get; set; }
        public Shipment shipment { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public bool enablePrePicking { get; set; }
        public Dictionary<string, Item> items { get; set; }
    }
    public class Operator
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    public class Shipment
    {
        public string method { get; set; }
        public string carrierName { get; set; }
    }
    public class Item
    {
        public string sku { get; set; }
        public int quantity { get; set; }
        public string stockType { get; set; }
        public int orderedQuantity { get; set; }
        public int returnedQuantity { get; set; }
        public int canceledQuantity { get; set; }
        public string itemType { get; set; }
        public bool presale { get; set; }
        public bool enablePicking { get; set; }
    }
