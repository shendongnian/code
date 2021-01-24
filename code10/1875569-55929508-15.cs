    public ActionResult CreateOrder(ICollection<OrderedProductViewModel> products)
    {
        if(products == null || !products.Any())
            throw new ArgumentException("Can't create an order without any selected products.");
    
        using (var context = new MyDbContext())
        {
            var order = new Order
            {
                OrderLines = products.Select(x => createOrderLine(context, x)).ToList(),
                // ... obviously other details, like the current user from session state...
            };
            context.Orders.Add(order);
            context.SaveChanges();
        }
    }
    
    private OrderLine createOrderLine(MyDbContext context, OrderedProductViewModel orderedProduct)
    {
        if (orderedProduct.Quantity <= 0 || orderedProduct.Quantity > MaximumOrderSize)
            throw new ArgumentException("orderedProduct.Quantity", "Naughty User!");
    
        var product = context.Products.Single(x => x.ProductId == orderedProduct.ProductId); 
        var orderLine = new OrderLine
        {
            Product = product,
            Quantity = orderedProduct.Quantity,
            UnitCost = product.Price,
            Cost = product.Price * orderedProduct.Quantity,
            // ...
        };
        return orderLine;
    }
