    public Order CreateOrder(int customerId, IEnumerable<OrderedProductViewModel> orderedProducts)
    {
        if (!orderedProducts.Where(x => x.Quantity > 0).Any())
           throw new ArgumentException("No products selected.");
    
        var customer = Context.Customers.Single(x => x.CustomerId == customerId);
        var products = Context.Products.Where(x => orderedProducts.Where(o => o.Quantity > 0).Select(o => o.ProductId).Contains(x.ProductId)).ToList();
        if (products.Count() < orderedProducts.Count())
           throw new ArgumentException("Invalid products included in order.");
       var order = new Order 
       { 
          Customer = customer,
          OrderLines = orderedProducts.Select(x => new OrderLine 
          { 
             Product = products.Single(p => p.ProductId == x.ProductId),
             Quantity = x.Quantity
          }
       }
       Context.Orders.Add(order);
       return order;
    }
