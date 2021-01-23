    public class Order
    {
         public...
         ...
         public OrderStatusWrapper OrderStatus { get; set; }
    }
    public ActionResult Index()
    {
        var result = _context.Orders.Where(o => o.OrderStatus == OrderStatus.ReadyForShipping);
        _context.Orders.Add(new Order{ ..., OrderStatus = OrderStatus.Shipped });
        ...;
    }
