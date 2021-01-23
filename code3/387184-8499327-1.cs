    Product product = new Product {
        ExpiryDate = new DateTime(2010, 12, 20, 18, 1, 0, DateTimeKind.Utc), Name = "Widget", Price = 9.99m, Sizes = new[] {
            "Small", "Medium", "Large"
        }
    };
    
    string json =
    JsonConvert.SerializeObject(
        product, 
        Formatting.Indented, 
        new JsonSerializerSettings {
        ContractResolver = new CamelCasePropertyNamesContractResolver()
    });
