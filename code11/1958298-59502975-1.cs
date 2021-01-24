    class OrdersStatsHandler
    {
        private readonly List<Order> _orderList = new List<Order>();
    
        public void HandleOrder(Order newOrder)
        {
            List<string> removeList = new List<string>() { newOrder.OrderId };
    
            switch (newOrder.OrdStatus)
            {
                case OrderStatus.Rejected:
                case OrderStatus.Filled:
                case OrderStatus.Canceled:
                    _orderList.RemoveAll(r => removeList.Any(a => a == r.OrderId));
                    break;
                case OrderStatus.New:
                case OrderStatus.PartiallyFilled:
                    if (_orderList.Where(o => o.OrderId == newOrder.OrderId).Count() == 0)
                        _orderList.Add(newOrder);
                    else
                    {
                        _orderList.RemoveAll(r => removeList.Any(a => a == r.OrderId));
                        _orderList.Add(newOrder);
                    }
                    break;
            }
        }
    
        public BindingSource GetBindingSource()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = _orderList;
            return bs;
        }
    } 
