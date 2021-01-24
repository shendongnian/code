    public class OrderService {
        public void AcceptOrder(Order order) {
            new OrderDatabase().SaveOrder(order);
        }
    }
