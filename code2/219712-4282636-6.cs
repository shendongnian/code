     class OrderServiceFacade
    {
        public bool SaveOrder(order order)
        {
           return  OrderDAO.SaveOrder(order);
        }
    }
