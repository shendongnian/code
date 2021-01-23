    public class Order : IOrder 
    { 
        public long Id { get; private set; } 
        public string Serial { get; private set; } 
        public long CustomerId { get; set; }
        public IOrderItems OrderItems { get; set; }
        
        public Order() { } 
        
        internal IOrderItems LoadOrderItems() 
        { 
            OrderItems = new OrderItems(Id); 
        } 
    }
