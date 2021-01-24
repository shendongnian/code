    public class Cart {
        List<CartItem> CartItems { get; set; }
        public int TotalQuantity => CartItems.Sum(x => x.Quantity);
        public decimal TotalPrice => CartItems.Sum(x => x.Price * x.Quantity);
        public Cart() {
            CartItems = new List<CartItem>();
        }
        public void AddItem(Guid itemId, string name, decimal price) {
            CartItem cartItem = CartItems.Find(x => x.ItemId == itemId);
            if (cartItem != null) {
                cartItem.Quantity += 1;
            } else {
                CartItems.Add(new CartItem(itemId, name, price, 1));
            }
        }
        class CartItem {
            public Guid ItemId { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public CartItem(Guid itemId, string name, decimal price, int quantity) {
                ItemId = itemId;
                Name = name;
                Price = price;
                Quantity = quantity;
            }
        }
    }
    class Program {
        static void Main(string[] args) {
            var test = new Cart.CartItem(Guid.Empty, "", 0.0m, 10); // Error CS0122  'Cart.CartItem' is inaccessible due to its protection level 
        }
    }
