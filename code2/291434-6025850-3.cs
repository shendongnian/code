    using (ProductsDataContext context = new ProductsDataContext())
    {
        context.Log = Console.Out;
        var p1 = context.Products.FirstOrDefault(p => p.ProductId == 1);
        var p2 = context.Products.Where(p => p.ProductId == 1).FirstOrDefault();
    }
