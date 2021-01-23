     class Product
     {
        public int ID { get; set; }
        public string Name { get; set; }
     }
    
     var product = new Product { ID = 99, Name = "haha" };
     AssignValue<Product, string>(p => p.Name, product, "changed");
