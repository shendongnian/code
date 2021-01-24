      using Newtonsoft.Json;
      public class Product{
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            [JsonIgnore]
            public DataTable dt = new DataTable();
            [JsonIgnore]
            public Category Category = new Category();
        }
