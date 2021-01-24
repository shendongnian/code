     var newestOrder = orderProducts.Where(op => op.DateOfShipping >= Today)
                       .Join(products, op => op.ProductId, pr => pr.Id, (op, pr) => new { pr.ProductName, op.DateOfShipping, op.OrderId })
    				   .Join(orders, op => op.OrderId, o => o.Id, (op, o) => new { op.ProductName, op.DateOfShipping, o.ClientId }).
                        Join(clients, o => o.ClientId, cl => cl.Id, (o, cl) => new { o.ProductName, o.DateOfShipping, cl.ClientName});
    					
        foreach (var n in newestOrder){
           Console.WriteLine("Date of shipping: {0}, Product Name: {1}, Client Name: {2}", n.DateOfShipping, n.ProductName, n.ClientName);
        }
