    public interface IOrderNumberGenerator
    {
        string Generate();
    }
    public class Order
    {
        private string orderNumber_;
        // default ctor
        public Order()
        {
        }   // eo ORder
        public Order(IOrderNumberGenerator generator, Order order)
        {
            orderNumber_ = generator.Generate();
            /* copy other fields from the existing Order*/
        }
        public string OrderNumber
        {
            get { return orderNumber_; }
        }
    }   // eo class Order
