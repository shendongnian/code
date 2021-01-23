    public class Order
    {
        // Other stuff
        public void RemoveOrderItem(int orderItemId)
        {
            var orderItemToRemove = OrderItems.First(oi => oi.Id == orderItemId)
            OrderItems.Remove(orderItemToRemove);
            DomainEvents.Raise(new OrderItemRemoved(orderItemToRemove));
        }
    }
