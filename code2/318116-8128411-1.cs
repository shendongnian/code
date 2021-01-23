    using (NorthwindContext context = new NorthwindContext())
    {
        var products = from p in context.Products
                       where p.Discontinued == false
                       select p;
        gridView.DataSource = products.ToList();
        gridView.DataBind();
    }
