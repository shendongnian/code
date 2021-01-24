    public ActionResult CreateOrder(int productId, int quantity)
    {
        if (quantity <= 0 || quantity > MaximumOrderSize)
            throw new ArgumentException("quantity", "Naughty User!");
        using (var context = new MyDbContext())
        {
            var product = context.Products.Single(x => x.ProductId == productId); // Ensures we have a valid product.
            var order = new Order
            {
                Product = product, // set references rather than FKs.
                Cost = product.Price * quantity,
                // ...
            };
            context.Orders.Add(order);
            context.SaveChanges();
        }
    }
