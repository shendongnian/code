    public static void Main(string[] args) {
        var orders = new List<Order>();
        var ruleset1 = new List<Func<Order, bool>>();
        var ruleset2 = new List<Func<Order, bool>>();
        AddRules(ruleset1);
        AddRules2(ruleset2);
        AddOrders(orders);
        foreach (var order in orders) {
            bool passed = true;
            foreach (var rule in ruleset1) {
                if (!(rule.Invoke(order))) {
                    passed = false;
                    Console.WriteLine("Order with Id " + order.Id + " did not pass ruleset 1");
                    break;
                }
            }
            if (passed) Console.WriteLine("Order with Id " + order.Id + " passed ruleset 1");
            passed = true;
            foreach (var rule in ruleset2) {
                if (!(rule.Invoke(order))) {
                    passed = false;
                    Console.WriteLine("Order with Id " + order.Id + " did not pass ruleset 2");
                    break;
                }
            }
            if (passed) Console.WriteLine("Order with Id " + order.Id + " passed ruleset 2");
        }
    }
    // Just a few orders for testing
    private static void AddOrders(List<Order> orders) {
        orders.Add(new Order() { Id = 0, ClientName = "Joe", Status = Order.OrderStatus.Confirmed });
        orders.Add(new Order() { Id = 1, ClientName = "Mary", Status = Order.OrderStatus.Confirmed });
        orders.Add(new Order() { Id = 2, ClientName = "June", Status = Order.OrderStatus.Confirmed });
        orders.Add(new Order() { Id = 3, ClientName = "Joe", Status = Order.OrderStatus.Unconfirmed });
        orders.Add(new Order() { Id = 4, ClientName = "Lisa", Status = Order.OrderStatus.Unconfirmed });
    }
    // Rules in ruleset 1 checks if the user is called Joe and the order status is Confirmed
    private static void AddRules(List<Func<Order, bool>> ruleset1) {
        ruleset1.Add((order) => {
            return order.ClientName == "Joe";
        });
        ruleset1.Add((order) => {
            return order.Status == Order.OrderStatus.Confirmed;
        });
    }
    // Rules in ruleset 2 checks if the order status is Confirmed
    private static void AddRules2(List<Func<Order, bool>> ruleset2) {
        ruleset2.Add((order) => {
            return order.Status == Order.OrderStatus.Confirmed;
        });
    }
    public class Order {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public OrderStatus Status { get; set; }
        public enum OrderStatus { Confirmed, Unconfirmed }
    }
Other than that, you could also use LINQ, as suggested by [@itsme86][1]:
    public static void Main(string[] args) {
        var orders = new List<Order>();
        AddOrders(orders);
        var confirmed = orders.Where(s => s.Status == Order.OrderStatus.Confirmed);
        foreach (var order in confirmed) {
            Console.WriteLine("Order with Id " + order.Id + " is confirmed");
        }
    }
    // Just a few orders for testing
    private static void AddOrders(List<Order> orders) {
        orders.Add(new Order() { Id = 0, ClientName = "Joe", Status = Order.OrderStatus.Confirmed });
        orders.Add(new Order() { Id = 1, ClientName = "Mary", Status = Order.OrderStatus.Confirmed });
        orders.Add(new Order() { Id = 2, ClientName = "June", Status = Order.OrderStatus.Confirmed });
        orders.Add(new Order() { Id = 3, ClientName = "Joe", Status = Order.OrderStatus.Unconfirmed });
        orders.Add(new Order() { Id = 4, ClientName = "Lisa", Status = Order.OrderStatus.Unconfirmed });
    }
    public class Order {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public OrderStatus Status { get; set; }
        public enum OrderStatus { Confirmed, Unconfirmed }
    }
  [1]: https://stackoverflow.com/users/1141432/itsme86
