    class Product {
       public string Name { get; private set; }
       public int Price { get; private set; }
       public Product(string name, int price) {
         Name = name; Price = price;
       }
  
       // Creates a new product using the current values and changing
       // the values of the specified arguments to a new value
       public Product With(string name = null, int? price = null) {
         return new Product(name ?? Name, price ?? Price);
       }
     }
     // Then you can write:
     var prod2 = prod1.With(name = "New product");
