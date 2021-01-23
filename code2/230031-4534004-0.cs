    class Program
    {
      class Product
      {
         public int ProductID { get; set; }
         public string ProductName {get; set; }
         public Product(int ProductID, string ProductName)
         {
            this.ProductID = ProductID;
            this.ProductName = ProductName;
         }
      }
      class Order
      {
         public int OrderID { get; set; }
         public int ProductID { get; set; }
         public decimal Amount { get; set; }
         public int Status { get; set; }
         public Order(int OrderID, Product product, decimal Amount, int Status)
         {
            this.OrderID = OrderID;
            this.ProductID = product.ProductID;
            this.Amount = Amount;
            this.Status = Status;
         }
      }
      private static Product[] Products;
      private static Order[] Orders;
      static void Main(string[] args)
      {
         Products = new Product[]
         {
            new Product(1, "Bolt"),
            new Product(2, "Nut"),
            new Product(3, "Mounting Plate A"),
            new Product(4, "Mounting Plate B")
         }; 
         Orders = new Order[]
         {
            new Order(1, Products[0], 1.12M, 0),
            new Order(2, Products[1], 0.66M, 1),
            new Order(3, Products[2], 4.12M, 0),
            new Order(4, Products[0], 1.11M, 1),
            new Order(5, Products[1], 0.67M, 1)
         };
         var results = from p in Products
                       join o in Orders on p.ProductID equals o.ProductID
                       where o.Status == 1
                       group o by p
                          into orderTotals
                          select new {ProductName = orderTotals.Key.ProductName, TotalAmount = orderTotals.Sum(o => o.Amount)};
         
         foreach(var result in results)
         {
            Console.WriteLine("{0}: {1}", result.ProductName, result.TotalAmount);
         }
      }
    }
