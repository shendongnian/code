      public class ItemList
      {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
      }
    
      public class ListInfo
      {
        [JsonProperty("info1")]
        public int Info1 { get; set; }
        [JsonProperty("info2")]
        public string Info2 { get; set; }
      }
    
      public class RootObject
      {
        [JsonProperty("itemList")]
        public List<ItemList> ItemList { get; set; }
        [JsonProperty("listInfo")]
        public ListInfo ListInfo { get; set; }
      }
