    List<ProductImage> productImages = new List<ProductImage>();
    for (int count = 1; count < 5; count++)
    {
       Product product = new Product { ProductId = productId };
       ProductImage productImage = new ProductImage();
       productImage.ImageNumber = count;
       productImage.Product = product;
       productImages.Add(productImage);
    }
    
    // ...
    context.ProductImages.AddRange(productImages);
