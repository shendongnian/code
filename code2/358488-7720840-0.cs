    public static void Main(string[] args)
    {
    	Order order = new Order();
    	
    	OrderLine line1 = new OrderLine(...);
    	OrderLine line2 = new OrderLine(...);
    	OrderLine line3 = new OrderLine(...);
    	
    	order.AddOrderLine(line1);
    	order.AddOrderLine(line2);
    	order.AddOrderLine(line3);
    
    	foreach (OrderLine line in orderLines)
    	{
    		Console.WriteLine(line.ToString());
    	}
    }
