    static void Exercise21()
    {
    	//List<Customer> customers = DataLoader.LoadCustomers();
    
    	var customers = GetCustomersMocks();
    	
    	string line = "{0,-35}";
    	Console.WriteLine(line, "Category");
    	Console.WriteLine("======================================================================================");
    
    	foreach (var customer in customers)
    	{
    		Console.WriteLine();
    		Console.WriteLine(customer.CompanyName);
    		var groupedOrdersList = (from c in customer.Orders group c by c.OrderDate);
    		foreach (var groupedOrders in groupedOrdersList)
    		{
    			Console.WriteLine(groupedOrders.Key);
    			Console.WriteLine(line, (from g in groupedOrders select g.Total).Sum());
    		}
    	}
    }
