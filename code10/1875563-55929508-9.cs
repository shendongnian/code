    public ActionResult CreateOrder(ProductViewModel product, int quantity)
    {
        if (quantity <= 0 || quantity > MaximumOrderSize)
            throw new ArgumentException("quantity", "Naughty User!");
        using (var context = new MyDbContext())
        {
            var order = new Order
            {
                ProductId = product.ProductId,
                Cost = product.Price * quantity,
                // ... obviously other details, like the current user from session state...
            };
            context.Orders.Add(order);
            context.SaveChanges();
        }
    }
