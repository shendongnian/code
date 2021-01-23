    public class Customer
      {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
      }
    
      class Order
      {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public string Description { get; set; }
      }
