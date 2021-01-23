    public class OrdersService : IOrderService
    {
        public IOrder LoadOrderOnly(long id)
        {
            var order = someDataAccessInstance.LoadOrder(id);
            return order;
        }
    
        public IOrder LoadOrderWithItems(long id)
        {
            var order = someDataAccessInstance.LoadOrder(id);
            order.LoadOrderItems();
            return order;
        }
    }
