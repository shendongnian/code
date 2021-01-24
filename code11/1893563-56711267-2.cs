    [DynamoDBTable("Inventory")]
      public class InventoryItem
      {
        [DynamoDBHashKey]   
        public int Id { get; set; }
    
        public string Status{ get; set; }
        public string Type{ get; set; }   
      }
