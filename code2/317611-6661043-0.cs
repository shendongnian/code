     class Product
     {
         public string DisplayName;
         public string URL;
     }
     List<Product> allProducts = new List<Product>();
     allProducts.Add(new Product { DisplayName = "A", URL = "A1" });
     allProducts.Add(new Product { DisplayName = "A", URL = "A2" });
     allProducts.Add(new Product { DisplayName = "A", URL = "A3" });
     allProducts.Add(new Product { DisplayName = "B", URL = "B1" });
     allProducts.Add(new Product { DisplayName = "B", URL = "B3" });
     var pGroups = from p in allProducts
                   group p by p.DisplayName into g
                   select new { DisplayName = g.Key, URLList = g };
     foreach (var p in pGroups)
     {
           Console.WriteLine("Product Name: " + p.DisplayName);
           foreach (var u in p.URLList)
           {
               Console.WriteLine("  URL: " + u.URL);
           }
     }
