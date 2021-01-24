    public class Customer
    {
    	public string CompanyName { get; set; }
    	public IEnumerable<Order> Orders { get; set; }
    }
    
    public class Order
    {
    	public DateTime OrderDate { get; set; }
    	public double Total { get; set; }
    }
    
    static IEnumerable<Customer> GetCustomersMocks()
    {
    	return new List<Customer>
    	{
    		new Customer
    		{
    			 CompanyName = "Ray's Company",
    			 Orders = new List<Order>
    			 {
    				 new Order { OrderDate = DateTime.Parse("11/1/1996 12:00:00 AM"), Total = 1148},
    				 new Order { OrderDate = DateTime.Parse("11/1/1996 12:00:00 AM"), Total = 1148}
    			 }
    		},
    		new Customer
    		{
    			 CompanyName = "Jay's Company",
    			 
    			 Orders = new List<Order>
    			 {
    				 new Order { OrderDate = DateTime.Parse("3/10/1997 12:00:00 AM"), Total = 478.34 },
    				 new Order { OrderDate = DateTime.Parse("3/10/1997 12:00:00 AM"), Total = 478.34 }
    			 }
    		},
    		new Customer
    		{
    			 CompanyName = "Bee's Company",
    			 Orders = new List<Order>
    			 {
    				 new Order { OrderDate = DateTime.Parse("11/13/1997 12:00:00 AM"), Total = 708 },
    				 new Order { OrderDate = DateTime.Parse("11/13/1997 12:00:00 AM"), Total = 708 }
    			 }
    		}
    	};
    }
