        interface IOrderController
    {
        bool SaveOrder(order order);
        bool ValidateOrder(order order);
        order GetOrder();
    }
    public class OrderBaseController : IOrderController
    {
        private OrderServiceFacade Orderhelper { get; set; }
        public OrderBaseController()
        {
            Orderhelper = new OrderServiceFacade();
        }
        public bool ValidateOrder(order objOrder)
        {
        }
        #region IOrderController Members
        public bool SaveOrder(order order)
        {
            bool success = false;
            if (ValidateOrder(order))
            {
               success = Orderhelper.SaveOrder(order);
            }
            return success;
        }
        #endregion
        #region IOrderController Members
        public order GetOrder()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
