    internal sealed class CustomerProxy : Customer
    {
       private bool _ordersLoaded = false;
        public override IList<Order> Orders
        {
            get
            {
                IList<Order> orders = new List<Order>();
                if (!_ordersLoaded)
                {
                    //assuming you are using mappers to translate entities to db and back
                    //mappers also live in the data layer
                    CustomerDataMapper mapper = new CustomerDataMapper();
                    orders = mapper.GetOrdersByCustomerID(this.ID);
                    _ordersLoaded = true;
                    // Cache Cases for later use of the instance
                    base.Orders = orders;
                }
                else
                {
                    orders = base.Orders;
                }
                return orders;
            }
       }
    }
