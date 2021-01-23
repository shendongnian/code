    public class OrderIDGenerator
    {
    
        private static readonly OrderIDGenerator instance = new OrderIDGenerator();
        private volatile int orderCount;
        private static object syncRoot = new object();
    
    
        private OrderIDGenerator()
        {
            orderCount = 1;
        }
    
    
        public static OrderIDGenerator Instance
        {
            get { return instance; }
        }
    
        public string GenerateOrderID()
        {
            lock (syncRoot)
                return String.Format("{0:yyyyMMddHHmmss}{1}", DateTime.Now, orderCount++);
        }
    }
