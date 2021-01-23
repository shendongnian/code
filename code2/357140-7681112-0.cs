    Class Member()
    {
        public string firstName { get; set; }
        public string lastName {get; set; }
        public int id { get; set;}
    }
    
    Class OrderLine()
    {
    
    }
    
    Class Order()
    {
        private List<OrderLine> orderLines;
        public Member submitter { get; set;}
    
        public Order()
        {
             orderLines = new List<OrderLine>();
        }
    
        public void AddOrderLine(OrderLine newOrderLine)
        {
             this.orderLines.Add(newOrderLine);
        }
    
        public IList<OrderLine> GetOrderLines()
        { 
             return this.orderLines;
        }
    }
