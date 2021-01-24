    string sql = "SELECT TOP 10 * FROM Orders AS A INNER JOIN OrderDetails AS B ON A.OrderID = B.OrderID;";
    
    using (var connection = new SqlCeConnection("Data Source=SqlCe_W3Schools.sdf"))
    {			
    	var orderDictionary = new Dictionary<int, Order>();
    
    
    	var list = connection.Query<Order, OrderDetail, Order>(
    	sql,
    	(order, orderDetail) =>
    	{
    		Order orderEntry;
    
    		if (!orderDictionary.TryGetValue(order.OrderID, out orderEntry))
    		{
    		orderEntry = order;
    		orderEntry.OrderDetails = new List<OrderDetail>();
    		orderDictionary.Add(orderEntry.OrderID, orderEntry);
    		}
    
    		orderEntry.OrderDetails.Add(orderDetail);
    		return orderEntry;
    	},
    	splitOn: "OrderID")
    	.Distinct()
    	.ToList();
    
    	Console.WriteLine(list.Count);
    
    	FiddleHelper.WriteTable(list);
    	FiddleHelper.WriteTable(list.First().OrderDetails);
    }
