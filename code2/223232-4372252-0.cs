    public class OrderIDGenerator {
        private static readonly OrderIDGenerator instance = new OrderIDGenerator();
        private int orderCount;
        private static readonly object _locker = new object();
    
        private OrderIDGenerator() {
                orderCount = 1;
        }
    
        public static OrderIDGenerator Instance {
                get { return instance; }
        }
    
        public string GenerateOrderID() {
            string orderId = "";
            lock (_locker) {
                orderID = String.Format("{0:yyyyMMddHHmmss}{1}", DateTime.Now, orderCount++);
            }
            return orderID;
        }
    }
