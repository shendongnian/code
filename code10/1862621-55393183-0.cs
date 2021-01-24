     public enum Status :int
        {
            Pending,
            Inprogress,
            Sent
    
        }
    
        public class OrderModel
        {
            public int OrderId { get; set; }
    
            // ...other properties
            public Status OrderStatus { get; set; }
        }
