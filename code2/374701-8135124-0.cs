    public class CustomerAndMostRecentOrder
    {
        public CustomerAndMostRecentOrder(Customer customer, Order mostRecentOrder)
        {
            Customer = customer;
            MostRecentOrder = mostRecentOrder;
        }
        public Customer Customer { get; set; }
        public Order MostRecentOrder { get; set; }
    }
    public class Order
    {
    }
    public class Customer
    {
        public IEnumerable<Order> GetOrders()
        {
            
        }
    }
    public static class UsageClass
    {
        public static void Sample(IEnumerable<Customer> allCustomers)
        {
            IEnumerable<CustomerAndMostRecentOrder> customerAndMostRecentOrders =
                allCustomers.Select(customer => new CustomerAndMostRecentOrder(customer, customer.GetOrders().Last()));
        }
    }
