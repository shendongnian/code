    public class OrderDetailsViewModel
    {
      public Order Order {get;set;}
      public List<Order> SimilarOrders {get;set;}
      public OrderDetailsViewModel(Order order, List<Order> similarOrders)
      {
        Order = order;
        SimilarOrders = similarOrders;
      }
    }
