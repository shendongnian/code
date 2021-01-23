     public virtual void AddOrderItem(OrderItem item)
        {
            item.Order = this;
            if (item.Order.OrderItems == null)
            {
                item.Order.OrderItems = new HashedSet<OrderItem>(); 
            }
            OrderItems.Add(item);
        }
