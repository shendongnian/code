    public class OrderRepository : IOrderRepository
    {
         private LegacyOrderService _legacyService;
         public OrderRepository(LegacyOrderService legacyService){
              _legacyService = legacyService;
         }
         public Order Add(Order order){
             if(!order.isNewOrder){
                  _legacyService.notify(order.id);
             }
             # do the rest
         }
    }
