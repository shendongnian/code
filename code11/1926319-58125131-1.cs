    List<ProductImage> productImages = new List<ProductImage>();
    Product product = context.Products.Single(x => x.ProductId == productId);
    for (int count = 1; count < 5; count++)
    {
       ProductImage productImage = new ProductImage();
       productImage.ImageNumber = count;
       productImage.Product = product;
       productImages.Add(productImage);
    }
    
    // ...
    context.ProductImages.AddRange(productImages);
