    public class Cart
    {
        // shorthand construnctor, only 1 setting, else use a normal function style constructor
        public Cart (Customer cust) => Customer = cust;
        public Customer Customer { get; set; }
        public Products Products { get; set; } = new List<Product>();
        public Payments Payments { get; set; } = new List<Payment>();
        public DateTime TimeOfArrival { get; set; } = DateTime.Now();
        //...and so on
    }
    var cart = new Cart( my_customer_instance );  // all thats needs to be done
