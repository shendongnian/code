lang-csharp
using System;
using System.Collections.Generic;
using System.Linq;
namespace CashRegister
{
   public class Product
   {
      public int ProductId { get; set; }
      public double ProductPrice { get; set; }
      public string ProductType { get; set; }
      public string ProductName { get; set; }
      // Rather than reading from a text file, I've just created this static method to return a few products
      // so I can do some testing.
      public static Product[] GetProducts()
      {
         return new Product[]
         {
            new Product
            {
               ProductId = 1,
               ProductPrice = 1.75d,
               ProductType = "Produce",
               ProductName = "Banana"
            },
            new Product
            {
               ProductId = 2,
               ProductPrice = 0.75d,
               ProductType = "Produce",
               ProductName = "Apple"
            },
            new Product
            {
               ProductId = 3,
               ProductPrice = 59.99,
               ProductType = "Electronics",
               ProductName = "Video Game"
            },
            new Product
            {
               ProductId = 4,
               ProductPrice = 39.99,
               ProductType = "Health",
               ProductName = "Aspirin"
            },
         };
      }
   }
   public class CartItem
   {
      public CartItem(Product product)
      {
         _product = product;
      }
      // I've exposed the properties of the Product class in this fashion, rather than exposing the Product itself
      // so that the Product cannot be modified through the CartItem. 
      public int ProductId => _product.ProductId;
      public double ProductPrice => _product.ProductPrice;
      public string ProductType => _product.ProductType;
      public string ProductName => _product.ProductName;
      public int Quantity { get; set; }
      // Here, we know the quantity and we know the product's price, so we can calculate the total price being
      // paid.
      public double TotalPrice => ProductPrice * Quantity;
      public override string ToString() =>
         string.Format("{0,-13}{1,-8:C}{2,-11}{3:C}", ProductName, ProductPrice, Quantity, TotalPrice);
      private readonly Product _product;
   }
   public class Cart
   {
      public void Add(Product product, int quantity)
      {
         // Look for an item in the cart for the given product.
         var item = _items.SingleOrDefault(ci => ci.ProductId == product.ProductId);
         if (item == null)
         {
            // If the given product is not already in the cart, create a new CartItem for that Product, and add
            // it to the cart.
            item = new CartItem(product);
            _items.Add(item);
         }
         // Increase the quantity being purchased.
         item.Quantity += quantity;
      }
      public void Print()
      {
         Console.WriteLine(" *** Customer Cart ***");
         Console.WriteLine("Item         Price   Quantity   Total");
         foreach (var item in _items)
         {
            Console.WriteLine(item.ToString());
         }
         Console.WriteLine("Total:                          {0:C}", Total);
      }
      // We can calculate the grand total based on the items in the cart.
      public double Total => _items.Sum(ci => ci.TotalPrice);
      private readonly List<CartItem> _items = new List<CartItem>();
   }
   class Program
   {
      static void Main(string[] args)
      {
         var products = Product.GetProducts();
         var cart = new Cart();
         var keepGoing = true;
         while (keepGoing)
         {
            cart.Print();
            Console.WriteLine();
            Console.WriteLine("<ItemId> <Quantity>");
            string answer = Console.ReadLine();
            if ("pay" != answer)
            {
               // There are several checks we should be doing, such as whether the "answer" is in the format
               // we expect and whether there is a Product with the given id.
               // But for the purposes of this example, we'll just assume everything is correct.
               var data = answer.Split(' ');
               var productId = int.Parse(data[0]);
               var quantity = int.Parse(data[1]);
               Product product = products.SingleOrDefault(p => p.ProductId == productId);
               cart.Add(product, quantity);
               Console.Clear();
            }
            else
            {
               keepGoing = false;
            }
         }
      }
   }
}
