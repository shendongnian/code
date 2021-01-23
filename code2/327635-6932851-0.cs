      public class Product
      {
        public string Name { get; private set; }
    
        public Decimal Price { get; private set; }
    
        public static List<Product> GetSampleProducts()
        {
          return new List<Product>()
          {
            new Product()
            {
              Name = "ProductA",
              Price = new Decimal(1233, 0, 0, false, (byte) 2)
            },
            new Product()
            {
              Name = "ProductB",
              Price = new Decimal(1332, 0, 0, false, (byte) 2)
            },
            new Product()
            {
              Name = "ProductC",
              Price = new Decimal(2343, 0, 0, false, (byte) 2)
            },
            new Product()
            {
              Name = "ProductD",
              Price = new Decimal(2355, 0, 0, false, (byte) 2)
            }
          };
        }
    
        public override string ToString()
        {
          return string.Format("{0}: {1}", (object) this.Name, (object) this.Price);
        }
      }
