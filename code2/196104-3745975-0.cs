     class Product
     {
       public int ProductID { get; set; }
     }
     static void Main(string[] args)
     {
       List<Product> products = new List<Product>()
          {   
             new Product { ProductID = 1 },
             new Product { ProductID = 2 },
             new Product { ProductID = 3 }
          };
       string theURL = string.Join("&", products.Select(p => string.Format("productID={0}", p.ProductID)));
       Console.WriteLine(theURL);
     }
