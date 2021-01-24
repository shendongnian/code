    public class OrderAdapter : IAdaptable<Order, OrderDTO>
    {
        IOtherDependentService _service;
        public OrderAdapter(IOtherDependentService service)
        {
            this._service = service;
        }
        OrderDTO ToDTO(Order order)
        {
           var orderPars = this._service.GetParsFromOrder(order.Id);
           var dto = new OrderDTO{
               Order = order, 
               Pars1 = orderPars.Pars1, 
               Pars2 = orderPars.Pars2
           };
           
           return dto;
            
        }
        
        //.... Implement the rest of the interface you get the picture
    }
