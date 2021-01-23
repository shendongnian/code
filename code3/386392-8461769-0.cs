     var query2 = ctx1.Order.Include("Order_Details").Select( o => new  
                 { o.OrderID,
                   o.CustomerID,
                   UnitPrices = o.Order_Details.Select( od => od.UnitPrice),
                   Quantities = o.Order_Details.Select( od => od.Quantity)
                  });
