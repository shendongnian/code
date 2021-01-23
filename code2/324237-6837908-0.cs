    Public Sub Linq76()
    	Dim customers As List(Of Customer) = GetCustomerList()
    
    	Dim orderCounts = From c In customers New With { _
    		c.CustomerID, _
    		Key.OrderCount = c.Orders.Count() _
    	}
    
    	ObjectDumper.Write(orderCounts)
    End Sub
