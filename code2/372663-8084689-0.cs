    public class OrdersViewModel
    {
    	public IEnumerable<Order> Orders { get; set; }
    	public OrderItems SelectedOrderItems { get; set; }
    }
    public ActionResult Orders(Guid id, Guid? orderId)
    {
    	var model = new OrdersViewModel();
    	model.Orders = Services.GetOrders(id);
    
    	if (orderId != null)
    	{
    	    model.SelectedOrderItems = Services.GetOrderLines(orderId);
    	}
    
    	return View(model);
    }
