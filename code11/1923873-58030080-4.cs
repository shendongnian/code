    public class OrderService {
        public void AcceptOrder(Order order) {
            //...Domain logic such as validation
            //then save order
            new OrderDatabase().SaveOrder(order);
        }
    }
