      using Newtonsoft.Json;
      public class Product{
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            [ScriptIgnore]
            public DataTable dt = new DataTable();
            [ScriptIgnore]
            public Category Category = new Category();
        }
