      public partial class Order
        {
            public bool IsOrderDelivered
            {
                get
                {
                    int orderDelivered = 1;
                    foreach (var orderItem in this.OrderItems)
                    {
                        orderDelivered = orderDelivered * orderItem.Delivered;
                    }
                    return orderDelivered == 1 ? true : false;
                }
            }
    
        }
