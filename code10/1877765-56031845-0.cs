    using (var context = new ProductContext())
    {
       var product = context.Products.Include(x => x.ProductSKUs).Single(x => x.Id = ID);
       product.IsActive = status;
       foreach( var productSKU in product.ProductSKUs)
           productSKU.IsActive = status;
    }
