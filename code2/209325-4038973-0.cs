    IEnumerable<Product> myFunction( Expression<Func<Product,object>> selector )
    {
        var products = new List<Product>();
        foreach (var c in dc.Products.Select( selector ))
        {
            var product = new Product();
            foreach (var property in c.GetType().GetProperties())
            {
                var productProperty = typeof(Product).GetProperty( property.Name );
                productProperty.SetValue( product, property.GetValue( c, null ) );
            }
            products.Add( product );
        }
        return products;
    }
