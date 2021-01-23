    public class OrdersListViewModel
    {
       public string CurrentItem {get;set;}
       public CustomerOrder[] CustomerOrders { get; set; }
       public PagingInfo PagingInfo { get; set; }
    }
    //and the controller action
    var model = new OrdersListViewModel
                     {
                         CurrentItem = orders.OrderByDescending(i => i.SalesPrice).FirstOrDefault().ItemNumber,
                         CustomerOrders = orders.ToArray(),
                         PagingInfo = new PagingInfo(...)
                     };
    return View(model);
