    public class OrderDetails
    {
        public int Id { get; set; }
        public int CartNumber { get; set; }
        public int CustomerId { get; set; }
        public int LineNumber { get; set; }
        public string PartNumber { get; set; }
        public int Qty { get; set; }
        public int SalesLocation { get; set; }
    }
    
    public async Task<OrderDetails> AddOrder(OrderDetails order)
    {
        await _context.OrderDetails.AddAsync(order);
        await SaveAll();
        var date = DateTime.Now.ToString("yyyyMMdd");
    
        using (StreamWriter writer = new StreamWriter(($"Y:\\WOL-0{order.CartNumber}-{order.CustomerId}-{date}-085715.txt")))
        {
            writer.WriteLine($"0{order.CartNumber}  {order.LineNumber}  {order.PartNumber}  {order.Qty} EA          {order.SalesLocation}   {order.SalesLocation}                                   EA                      Y                                                       ");        
        }
        return order;
    }
