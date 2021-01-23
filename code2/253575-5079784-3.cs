    public class Order
    {
        public List<OrderItem> Items{get; private set;}
        public Customer OrderedBy {get; private set;}
        //Other stuff
    }
    public class Customer
    {
      public List<Orders> Orders{get;set;}
    }
