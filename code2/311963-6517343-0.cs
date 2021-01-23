    public void SaveProduct(Product product)
    {
        if (product.ProductID == 0)
        {
            context.Products.Add(product);
        }
        else    // Update operation
        {
            context.Products.Attach(product);
        }
        context.SaveChanges();
    }
