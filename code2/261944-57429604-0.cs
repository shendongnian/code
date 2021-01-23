    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }        
    }
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
    public class Address
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
    }
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var customerLines = System.IO.File.ReadAllLines(@"Customers.csv");
            var orderLines = System.IO.File.ReadAllLines(@"Orders.csv");
            var orderItemLines = System.IO.File.ReadAllLines(@"OrderItemLines.csv");
            CsvFactory.Register<Customer>(builder =>
            {
                builder.Add(a => a.Id).Type(typeof(int)).Index(0).IsKey(true);
                builder.Add(a => a.Name).Type(typeof(string)).Index(1);
                builder.AddNavigation(n => n.Orders).RelationKey<Order, int>(k => k.CustomerId);
            }, false, ',', customerLines);
            CsvFactory.Register<Order>(builder =>
            {
                builder.Add(a => a.Id).Type(typeof(int)).Index(0).IsKey(true);
                builder.Add(a => a.CustomerId).Type(typeof(int)).Index(1);
                builder.Add(a => a.Quantity).Type(typeof(int)).Index(2);
                builder.Add(a => a.Amount).Type(typeof(int)).Index(3);
                builder.AddNavigation(n => n.OrderItems).RelationKey<OrderItem, int>(k => k.OrderId);
            }, true, ',', orderLines);
            CsvFactory.Register<OrderItem>(builder =>
            {
                builder.Add(a => a.Id).Type(typeof(int)).Index(0).IsKey(true);
                builder.Add(a => a.OrderId).Type(typeof(int)).Index(1);
                builder.Add(a => a.ProductName).Type(typeof(string)).Index(2);
            }, false, ',', orderItemLines);
            var customers = CsvFactory.Parse<Customer>();
        }
    }
