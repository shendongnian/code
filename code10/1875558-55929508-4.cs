    public ActionResult CreateOrder(Product product, int quantity)
    {
        if (quantity <= 0 || quantity > MaximumOrderSize)
            throw new ArgumentException("quantity", "Naughty User!");
        using (var context = new MyDbContext())
        {
            var order = new Order
            {
                Product = product,
                Cost = product.Price * quantity,
                // ...
            };
            context.Orders.Add(order);
            context.SaveChanges();
        }
    }
