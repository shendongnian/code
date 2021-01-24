    List<ProductImage> productImages = new List<ProductImage>();
    Product product = context.Products.Single(x => x.ProductId == productId);
    ProductImage productImage = new ProductImage();
    for (int count = 1; count < 5; count++)
    {
       productImage.ImageNumber = count;
       productImage.Product = product;
       productImages.Add(productImage);
    }
    
    // ...
    context.ProductImages.AddRange(productImages);
