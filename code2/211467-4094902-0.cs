    public class Order  
    {  
        public string OrderNo { get; set; }  
        public string CustomerName { get; set; }  
    
        public List<OrderLine> Lines { get; set; }  
        public Order()
        {
             this.Lines = new List<OrderLine>();
        }
    } 
